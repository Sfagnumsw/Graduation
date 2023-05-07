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
    public class TaskService : IBaseService<G_DAL.Entity.Task>
    {
        private readonly ILogger<TaskService> _logger;
        private readonly IBaseAction<G_DAL.Entity.Task> _repos;
        public TaskService(ILogger<TaskService> logger, IBaseAction<G_DAL.Entity.Task> repos) 
        {
            _logger = logger;
            _repos = repos;
        }

        public async System.Threading.Tasks.Task Create(G_DAL.Entity.Task obj)
        {
            try
            {
                await _repos.Create(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<G_DAL.Entity.Task> Get(int objId)
        {
            G_DAL.Entity.Task task = null;
            try
            {
                task = await _repos.Get(objId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return task;
        }

        public async Task<IEnumerable<G_DAL.Entity.Task>> GetAll()
        {
            IEnumerable<G_DAL.Entity.Task> tasks = new List<G_DAL.Entity.Task>();
            try
            {
                tasks = await _repos.GetAll();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return tasks;
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
