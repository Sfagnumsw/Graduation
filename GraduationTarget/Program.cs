using G_DAL;
using G_DAL.Entity;
using G_DAL.Interface;
using G_DAL.Repository;
using G_DAL.ViewModel;
using G_Service.Interface;
using G_Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using System.Text;

namespace GraduationTarget
{
    public class Program
    {
        public static IConfiguration Configuration { get; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.AddNLog();

            builder.Services.AddDbContext<G_ContextDB>(options => options.UseSqlServer("Server=localhost;Database=GradDB;User Id=sa;Password=Qwerty12345;", a => a.MigrationsAssembly("GraduationTarget")));
            builder.Services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<G_ContextDB>();

            builder.Services.ConfigureApplicationCookie(opt => opt.LoginPath = "/User/SignIn");

            builder.Services.AddScoped<IBaseService<G_DAL.Entity.Task>, TaskService>();
            builder.Services.AddScoped<IBaseAction<G_DAL.Entity.Task>, TaskRepos>();
            builder.Services.AddScoped<IBaseService<Team>, TeamService>();
            builder.Services.AddScoped<IBaseAction<Team>, TeamRepos>();
            builder.Services.AddScoped<IBaseService<Project>, ProjectService>();
            builder.Services.AddScoped<IBaseAction<Project>, ProjectRepos>();
            builder.Services.AddScoped<IBaseService<Status>, StatusService>();
            builder.Services.AddScoped<IBaseAction<Status>, StatusRepos>();
            builder.Services.AddScoped<IBaseService<Stage>, StageService>();
            builder.Services.AddScoped<IBaseAction<Stage>, StageRepos>();
            builder.Services.AddScoped<IBaseService<Notion>, NotionService>();
            builder.Services.AddScoped<IBaseAction<Notion>, NotionRepos>();
            builder.Services.AddScoped<IBaseUserService, UserService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));
            var key = builder.Configuration.GetSection("JWT:Key").Value;
            var issuer = builder.Configuration.GetSection("JWT:Issuer").Value;
            var audience = builder.Configuration.GetSection("JWT:Audience").Value;
            var symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = issuer,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = audience,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = symKey,
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                };
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
            app.Run();
        }
    }
}