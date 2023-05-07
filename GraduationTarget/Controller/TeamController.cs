using G_DAL.Entity;
using G_Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationTarget.Controller
{
    public class TeamController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseService<Team> _serviceTeam;
        private readonly IBaseUserService _userService;
        public TeamController(IBaseService<Team> serviceTeam, IBaseUserService userService)
        {
            _serviceTeam = serviceTeam;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyTeam()
        {
            var teams = await _serviceTeam.GetAll();
            var user = await _userService.GetCurrentUser();
            var myTeam = teams.Where(i => i.Id == user.Team.Id).FirstOrDefault();
            var friends = await _userService.GetInTeam(myTeam.Id);
            ViewBag.Team = myTeam.Name;
            return View(friends);
        }
    }
}