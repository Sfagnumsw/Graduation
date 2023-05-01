using G_DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationTarget.Controller
{
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
