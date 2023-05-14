using G_DAL.Entity;
using G_DAL.ViewModel;
using G_Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationTarget.Controller
{
    public class ProjectController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseService<Project> _projectService;
        private readonly IBaseUserService _userService;
        private readonly IBaseService<Stage> _stageService;
        private readonly IBaseService<Status> _statusService;
        public ProjectController(IBaseService<Project> projectService, IBaseUserService userService, IBaseService<Stage> stageService, IBaseService<Status> statusService)
        {
            _projectService = projectService;
            _userService = userService;
            _stageService = stageService;
            _statusService = statusService;
        }

        [Authorize]
        public async Task<IActionResult> ProjectPage()
        {
            var user = await _userService.GetCurrent();
            var projects = await _projectService.GetAll();
            var myProject = projects.FirstOrDefault(i => i.TeamId.Equals(user.TeamId));
            ProjectViewModel projectModel = null;
            if (myProject != null)
            {
                var stage = await _stageService.Get(myProject.StageId.Value);
                var status = await _statusService.Get(stage.StatusId);
                projectModel = new G_DAL.ViewModel.ProjectViewModel()
                {
                    Name = myProject.Name,
                    Description = myProject.Description,
                    Stage = stage.Name,
                    Status = status.Name,
                    Color = status.Color,
                    StageDescription = stage.Description,
                    StatusDescription = status.Description
                };
            }
            return View(projectModel);
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
