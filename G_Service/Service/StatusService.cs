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
    public class StatusService : IBaseService<Status>
    {
        private readonly ILogger<StatusService> _logger;
        private readonly IBaseAction<Status> _repos;
        public StatusService(ILogger<StatusService> logger, IBaseAction<Status> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<Status> Create(Status obj)
        {
            Status status = null;
            try
            {
                var statuses = await _repos.GetAll();
                if(statuses.Where(i => i.Name == obj.Name).Any())
                {
                    throw new Exception("Такой статус уже существует");
                }
                status = await _repos.Create(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return status;
        }

        public async Task<Status> Get(int objId)
        {
            Status status = null;
            try
            {
                status = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return status;
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            IEnumerable<Status> statuses = new List<Status>();
            try
            {
                statuses = await _repos.GetAll();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return statuses;
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
