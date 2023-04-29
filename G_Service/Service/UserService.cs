using G_DAL.Entity;
using G_Service.Interface;
using G_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace G_Service.Service
{
    public class UserService : IBaseService<User>
    {
        private readonly ILogger<UserService> _logger;
        private readonly IBaseAction<User> _repos;
        public UserService(ILogger<UserService> logger,IBaseAction<User> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<User> Create(User model)
        {
            User user = null;
            try
            {
                var users = await _repos.GetAll();
                if (users.Where(i => i.UserName == model.UserName).Any() || users.Where(i => i.Email == model.Email).Any())
                {
                    throw new Exception("Такой пользователь уже существует");
                }
                user = await _repos.Create(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return user;
        }

        public async Task<User> Get(int objId)
        {
            User user = null;
            try
            {
                user = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = new List<User>();
            try
            {
                users = await _repos.GetAll();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return users;
        }

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            try
            {
                await _repos.Remove(objId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
