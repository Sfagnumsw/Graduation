using G_DAL.Entity;
using G_DAL.ViewModel;
using G_Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace GraduationTarget.Controller
{
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBaseUserService _userService;
        public UserController(IBaseUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            await _userService.Create(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel model)
        {
            await _userService.SignIn(model);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public  async Task<IActionResult> LogOut()
        {
            await _userService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
