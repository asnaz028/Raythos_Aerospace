using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Raythos_Aerospace.Models.ViewModels;
using Raythos_Aerospace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserManager _userManager;

        public UserAccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult CustomerProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.RegisterUserAsync(model);

            if (result)
            {
                return View();
            }

            return BadRequest(new { Message = "Registration failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.LoginUserAsync(model);

            if(result.IsNullOrEmpty())
            {
                TempData["Error"] = "Email or password is incorrect";
                return View();
            }

            HttpContext.Session.SetString("AccessToken", result);
            return View();

        }



    }
}
