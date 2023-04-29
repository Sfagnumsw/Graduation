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
    public class StageService : IBaseService<Stage>
    {
        private readonly ILogger<StageService> _logger;
        private readonly IBaseAction<Stage> _repos;
        public StageService(ILogger<StageService> logger, IBaseAction<Stage> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<Stage> Create(Stage model)
        {
            Stage stage = null;
            try
            {
                var stages = await _repos.GetAll();
                if (stages.Where(i => i.Name == model.Name).Any())
                {
                    throw new Exception("Такая стадия проекта уже существует");
                }
                stage = await _repos.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return stage;
        }

        public async Task<Stage> Get(int objId)
        {
            Stage stage = null;
            try
            {
                stage = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return stage;
        }

        public async Task<IEnumerable<Stage>> GetAll()
        {
            IEnumerable<Stage> stages = new List<Stage>();
            try
            {
                stages = await _repos.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return stages;
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
