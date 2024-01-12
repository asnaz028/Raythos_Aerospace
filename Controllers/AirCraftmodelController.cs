using Microsoft.AspNetCore.Mvc;
using Raythos_Aerospace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Controllers
{
    public class AirCraftmodelController : Controller
    {
        private readonly IAircraftService _aircraftService;

        public AirCraftmodelController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }
        public IActionResult Index()
        {
            var aircraftList = _aircraftService.GetAircraftsAsync().Result;
            return View(aircraftList);
        }

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
       
    }
}
