using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;

namespace HW4Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RGBColor(int? red, int? green, int? blue)
        {
            Debug.WriteLine("inside RGBColor action method");

            RGBColorModel myColor = new RGBColorModel();
            if (red != null && green !=null && blue != null)
            {
                Debug.WriteLine("RGB = " + red + ", " + green + ", " + blue);
               
                myColor.Red = red;
                myColor.Green = green;
                myColor.Blue = blue;
            }

            return View("RGBColor", myColor);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
