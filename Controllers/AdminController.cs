using Microsoft.AspNetCore.Mvc;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using Raythos_Aerospace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAircraftService _aircraftService;
        private readonly IUserManager _userManager;

        public AdminController(IAircraftService aircraftService, IUserManager userManager)
        {
            _userManager = userManager;
            _aircraftService = aircraftService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        async public Task<IActionResult> ManageUsers()
        {
            var users = await _userManager.GetUsers();
            Console.WriteLine(users);

            return View(users);
        }
        public IActionResult ManageOrders()
        {
            return View();
        }
        async public Task<IActionResult> ManageInventory()
        {
            var result = await _aircraftService.GetAircraftsAsync();
            return View(result);
        }
        public IActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> AddInventory([FromForm] AircraftViewModel model)
        {

            var result = await _aircraftService.CreateAircraftAsync(model);

            if (!result)
            {
                TempData["Error"] = "Cannot create the item";
            }

            return View();
            
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUser(int userId)
        {
            try
            {
                // Perform the user deletion logic using your UserManager
                var success = await _userManager.DeleteUserAsync(userId);

                if (success)
                {
                    return Json(new { success = true, message = "User deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error deleting user" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Json(new { success = false, message = "An error occurred while deleting user" });
            }
        }


        public IActionResult SalesReport()
        {
            DateTime currentDate = DateTime.Now;
            ViewBag.CurrentDate = currentDate;
            return View();
        }
        public IActionResult InventoryReport()
        {
            DateTime currentDate = DateTime.Now;
            ViewBag.CurrentDate = currentDate;
            return View();
        }
        public IActionResult CustomerCustomizationReport()
        {
            DateTime currentDate = DateTime.Now;
            ViewBag.CurrentDate = currentDate;
            return View();
        }
        public IActionResult EditInventory(int id)
        {
             
            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> EditInventory([FromBody] AircraftEntity model)
        {
            var result = await _aircraftService.EditAircraftAsync(model);

            if (!result)
            {
                TempData["Error"] = "Cannot edit this aircraft";
                return NotFound(); 
            }

           
            return View();
        }
        public IActionResult UpdateOrderStatus(int id)
        {

            return View(id);
        }
        public IActionResult ShippingandDelivary(int id)
        {
             
            return View(id);
        }
        public IActionResult ShippingandDeliveryReport()
        {
            DateTime currentDate = DateTime.Now;
            ViewBag.CurrentDate = currentDate;
            return View();
        }

    }
}
