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
        public async Task<IActionResult> TeamPage()
        {
            IEnumerable <User> friends = new List<User>();
            var teams = await _serviceTeam.GetAll();
            var user = await _userService.GetCurrentUser();
            if(user.TeamId != null)
            {
                var myTeam = teams.Where(i => i.Id == user.TeamId).FirstOrDefault();
                friends = await _userService.GetInTeam(myTeam.Id);
                ViewBag.Team = myTeam.Name;
            }
            return View(friends);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team model)
        {
            await _serviceTeam.Create(model);
            return RedirectToAction("TeamPage");
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string mail)
        {
            var user = await _userService.Get(mail);
            var current = await _userService.GetCurrentUser();
            await _userService.AddToTeam(user, current.TeamId.Value);
            return RedirectToAction("TeamPage");
        }
    }
}