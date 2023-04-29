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
    public class TeamService : IBaseService<Team>
    {
        private readonly ILogger<TeamService> _logger;
        private readonly IBaseAction<Team> _repos;
        public TeamService(ILogger<TeamService> logger, IBaseAction<Team> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<Team> Create(Team model)
        {
            Team team = null;
            try
            {
                team = await _repos.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return team;
        }

        public async Task<Team> Get(int objId)
        {
            Team team = null;
            try
            {
                team = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return team;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            IEnumerable<Team> teams = new List<Team>();
            try
            {
                teams = await _repos.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return teams;
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
