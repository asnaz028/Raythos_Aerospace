using Microsoft.AspNetCore.Mvc;
using Raythos_Aerospace.Models.ViewModels;
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
        async public Task<IActionResult> ShoppingCart()
        {
            var orders = await _aircraftService.GetOrdersAsync("Cart");
            decimal totalPrice = orders.Sum(item => item.Price * item.Quantity);

            ViewBag.TotalPrice = totalPrice;
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromForm] CartItemData cartItemData)
        {
            if (cartItemData == null)
            {
                // Handle invalid input
                return BadRequest("Invalid data");
            }

            // Get the user ID (replace this with your actual logic to get the user ID)
            int userId = 4;

            // Call the service method to add the item to the cart
            await _aircraftService.AddToCartAsync(
                cartItemData.AircraftModelId,
                userId,
                cartItemData.Price,
                cartItemData.SeatingConfiguration,
                cartItemData.InteriorDesign,
                cartItemData.AdditionalFeatures,
                cartItemData.Quantity
            );

            // Return a JSON response indicating success
            return Json(new { success = true });
        }

    }
}
