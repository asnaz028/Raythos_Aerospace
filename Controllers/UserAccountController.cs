using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Raythos_Aerospace.Models.ViewModels;
using Raythos_Aerospace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

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
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            /*if (HttpContext.Session.GetString("AccessToken") != null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to '/' route
            }*/
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.RegisterUserAsync(model);

            if (result == 0)
            {
                TempData["Error"] = "Cannot register the user";
                return View();
            }

            
            return RedirectToAction("Index", "");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (HttpContext.Session.GetString("AccessToken") != null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to '/' route
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.LoginUserAsync(model);

            if(result == 0)
            {
                TempData["Error"] = "Email or password is incorrect";
                return View();
            }

            ViewBag.UserId = result;

            HttpContext.Session.SetString("AccessToken", result.ToString());
            return RedirectToAction("Index", "");

        }



    }
}
