using G_DAL;
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
    public class NotionService : IBaseService<Notion>
    {
        private readonly IBaseAction<Notion> _repos;
        private readonly ILogger<NotionService> _logger;
        private readonly IBaseUserService _userService;
        public NotionService(IBaseAction<Notion> repos, IBaseUserService userService, ILogger<NotionService> logger)
        {
            _repos = repos;
            _userService = userService;
            _logger = logger;
        }

        public async System.Threading.Tasks.Task Create(Notion model)
        {
            try
            {
                var user = await _userService.GetCurrent();
                model.UserMail = user.Email;
                await _repos.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<Notion> Get(int objId)
        {
            Notion notion = null;
            try
            {
                notion = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return notion;
        }

        public async Task<IEnumerable<Notion>> GetAll()
        {
            IEnumerable<G_DAL.Entity.Notion> notions = new List<G_DAL.Entity.Notion>();
            try
            {
                notions = await _repos.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return notions;
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
