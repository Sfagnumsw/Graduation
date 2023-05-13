using G_DAL.Entity;
using G_DAL.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace G_Service.Interface
{
    public interface IBaseUserService
    {
        System.Threading.Tasks.Task Create(UserModel model);
        Task<User> Get(string email);
        Task<IEnumerable<User>> GetInTeam(int teamId);
        Task<User> GetCurrent();
        System.Threading.Tasks.Task<string> SignIn(UserModel model);
        System.Threading.Tasks.Task SignOut();
        System.Threading.Tasks.Task<User> GetCurrentUser();
        System.Threading.Tasks.Task AddToTeam(User user, int teamID);

    }
}
