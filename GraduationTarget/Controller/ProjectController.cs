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
        public async Task<IActionResult> GetMyProject()
        {
            var user = await _userService.GetCurrent();
            var projects = await _projectService.GetAll();
            var myProject = projects.FirstOrDefault(i => i.Team.Equals(user.Team));
            return View(myProject);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Create(Project model)
        {
            await _projectService.Create(model);
            return View("Index");
        }
    }
}
