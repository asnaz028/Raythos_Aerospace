using Microsoft.AspNetCore.Mvc;
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
                return BadRequest(ModelState);
            }

            var result = await _userManager.RegisterUserAsync(model);

            if (result)
            {
                return Ok(new { Message = "Registration successful." });
            }

            return BadRequest(new { Message = "Registration failed." });
        }
    }
}
