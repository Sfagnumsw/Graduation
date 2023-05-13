using G_DAL.Entity;
using G_Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationTarget.Controller
{
    public class ProjectController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseService<Project> _projectService;
        private readonly IBaseUserService _userService;
        public ProjectController(IBaseService<Project> projectService, IBaseUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> ProjectPage()
        {
            var user = await _userService.GetCurrent();
            var projects = await _projectService.GetAll();
            var myProject = projects.FirstOrDefault(i => i.TeamId.Equals(user.TeamId));
            return View(myProject);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Project model)
        {
            await _projectService.Create(model);
            return RedirectToAction("ProjectPage");
        }
    }
}
