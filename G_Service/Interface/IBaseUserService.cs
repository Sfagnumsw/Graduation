﻿using G_DAL.Entity;
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
    internal interface IBaseUserService
    {
        System.Threading.Tasks.Task Create(UserModel model);
        Task<User> Get(string email);
        Task<IEnumerable<User>> GetInRole(string roleName);
        Task<User> GetCurrent();
        System.Threading.Tasks.Task<string> SignIn(UserModel model);
        System.Threading.Tasks.Task SignOut();
    }
}
