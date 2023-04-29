using G_DAL.Entity;
using G_DAL.Interface;
using G_Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Service.Service
{
    public class RoleService : IBaseService<Role>
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IBaseAction<Role> _repos;
        public RoleService(ILogger<RoleService> logger, IBaseAction<Role> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<Role> Create(Role model)
        {
            Role role = null;
            try
            {
                var roles = await _repos.GetAll();
                if (roles.Where(i => i.Name == model.Name).Any())
                {
                    throw new Exception("Роль с таким названием уже существует");
                }
                role = await _repos.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return role;

        }

        public async Task<Role> Get(int objId)
        {
            Role role = null;
            try
            {
                role = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return role;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            IEnumerable<Role> roles = new List<Role>();
            try
            {
                roles = await _repos.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return roles;
        }

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            try
            {
                await _repos.Remove(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
