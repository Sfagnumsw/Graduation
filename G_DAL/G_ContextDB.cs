using G_DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace G_DAL
{
    public class G_ContextDB : IdentityDbContext<User, Role, int>
    {
        public G_ContextDB(DbContextOptions<G_ContextDB> opt) : base(opt) { }

        public DbSet<Project> Project { get; set; }
        public DbSet<Stage> Stage { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Entity.Task> Task { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "admin",
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "user",
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = "projectOwner",
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 4,
                Name = "curator",
            });

            modelBuilder.Entity<Stage>().HasData(new Stage
            {
                Id = 1,
                Name ="Проектирование",
                Description = "Стадия проектирования"
            });

            modelBuilder.Entity<Stage>().HasData(new Stage
            {
                Id = 2,
                Name = "Разработка",
                Description = "Стадия разработки"
            });

            modelBuilder.Entity<Stage>().HasData(new Stage
            {
                Id = 3,
                Name = "Тестирование",
                Description = "Стадия тестирования"
            });

            modelBuilder.Entity<Stage>().HasData(new Stage
            {
                Id = 4,
                Name = "Завершение",
                Description = "Стадия завершения"
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 1,
                Name = "По плану",
                Description = "Стадия проекта соответствует срокам",
                Color = "#008000"
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 2,
                Name = "Под угрозой",
                Description = "Есть риск сорвать сроки стадии",
                Color = "#FF8C00"
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 3,
                Name = "Отстает",
                Description = "Сроки стадии проекта сорваны",
                Color = "#FF0000"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "sfagnumX",
                Email = "swimming1999@mail.ru",
                NormalizedUserName = "SFAGNUMX",
                NormalizedEmail = "SWIMMING1999@MAIL.RU",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Qwerty12345"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}
