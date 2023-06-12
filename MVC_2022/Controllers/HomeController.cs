﻿using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using System.Diagnostics;

namespace MVC_2022.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            TempData["Nome"] = "Henrick Melo Vital";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}