using G_Service.Interface;
using G_DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GraduationTarget.Controller
{
    public class TaskController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseService<G_DAL.Entity.Task> _serviceTask;
        private readonly IBaseUserService _serviceUser;
        public TaskController(IBaseService<G_DAL.Entity.Task> serviceTask, IBaseUserService serviceUser)
        {
            _serviceTask = serviceTask;
            _serviceUser = serviceUser;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(G_DAL.ViewModel.TaskViewModel model)
        {
            var creator = await _serviceUser.GetCurrentUser();
            var performer = await _serviceUser.Get(model.PerformerMail);
            G_DAL.Entity.Task task = new G_DAL.Entity.Task()
            {
                Name = model.Name,
                Description = model.Description,
                End = model.End,
                Creator = creator,
                Performer = performer
            };
            await _serviceTask.Create(task);
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TaskPage()
        {
            var user = await _serviceUser.GetCurrentUser();
            var allTasks = await _serviceTask.GetAll();
            var myTasks = allTasks.Where(i => i.Performer.Id == user.Id);
            return View(myTasks);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Complete(int TaskId)
        {
            await _serviceTask.Remove(TaskId);
            return Content("Good");
        }
    }
}
