using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace GraduationTarget.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
