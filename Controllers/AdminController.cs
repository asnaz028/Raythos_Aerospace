using Microsoft.AspNetCore.Mvc;
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

        public AdminController(IAircraftService aircraftService)
        {
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
        public IActionResult ManageUsers()
        {
            return View();
        }
        public IActionResult ManageOrders()
        {
            return View();
        }
        public IActionResult ManageInventory()
        {
            return View();
        }
        public IActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> AddInventory([FromBody] AircraftViewModel model)
        {

            var result = await _aircraftService.CreateAircraftAsync(model);

            if (!result)
            {
                TempData["Error"] = "Cannot create the item";
            }

            return View();
            
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
