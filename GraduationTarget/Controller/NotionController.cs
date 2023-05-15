using G_DAL.Entity;
using G_Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GraduationTarget.Controller
{
    public class NotionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseService<Notion> _notionService;
        public NotionController(IBaseService<Notion> notionService)
        {
            _notionService = notionService;
        }

        public async System.Threading.Tasks.Task<IActionResult> NotionPage()
        {
            var notions = await _notionService.GetAll();
            return View(notions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notion model)
        {
            await _notionService.Create(model);
            return RedirectToAction("NotionPage");
        }
    }
}
