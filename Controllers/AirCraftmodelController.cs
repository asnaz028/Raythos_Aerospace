﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Controllers
{
    public class AirCraftmodelController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
