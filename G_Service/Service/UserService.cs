using G_DAL.Entity;
using G_DAL.ViewModel;
using G_Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace G_Service.Service
{
    public class UserService : IBaseUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTSettings _settings;
        public UserService(ILogger<UserService> logger, UserManager<User> user, SignInManager<User> data, JWTSettings settings)
        {
            _logger = logger;
            _userManager = user;
            _signInManager = data;
            _settings = settings;
        }

        public async System.Threading.Tasks.Task Create(UserModel model)
        {
            User user = null;
            try
            {
                user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    Claim claim = new Claim(ClaimTypes.Email, model.Email);
                    await _userManager.AddClaimAsync(user, claim);
                    await _userManager.AddToRoleAsync(user, "user");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<User> Get(string email)
        {
            User user = null;
            try
            {
                user = await _userManager.FindByEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return user;
        }

        public async Task<User> GetCurrent()
        {
            User user = null;
            try
            {
                var claims = _signInManager.Context.User;
                user = await _userManager.GetUserAsync(claims);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetInRole(string roleName)
        {
            IList<User> users = new List<User>();
            try
            {
                users = await _userManager.GetUsersInRoleAsync(roleName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return users;
        }

        public async System.Threading.Tasks.Task<string> SignIn(UserModel model)
        {
            string token = null;
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    var claims = await _userManager.GetClaimsAsync(user);
                    token = GetToken(user, claims);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return token;
        }

        private string GetToken(User user, IEnumerable<Claim> principal)
        {
            var claims = principal.ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var jwt = new JwtSecurityToken(_settings.Issuer, _settings.Audience, claims,
                DateTime.UtcNow, DateTime.UtcNow.AddDays(1), new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async System.Threading.Tasks.Task SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
