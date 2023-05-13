using G_DAL.Entity;
using G_DAL.Interface;
using G_Service.Interface;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public TeamService(ILogger<TeamService> logger, IBaseAction<Team> repos, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _repos = repos;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async System.Threading.Tasks.Task Create(Team model)
        {
            try
            {
                await _repos.Create(model);
                var teams = await _repos.GetAll();
                var currentTeam = teams.FirstOrDefault(i => i.Name == model.Name);
                var claims = _signInManager.Context.User;
                var user = await _userManager.GetUserAsync(claims);
                user.TeamId = currentTeam.Id;
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
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
