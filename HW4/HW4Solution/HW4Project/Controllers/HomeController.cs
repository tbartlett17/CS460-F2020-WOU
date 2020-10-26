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
        public IActionResult RGBInterpolator()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RGBInterpolator(ColorInterpolation c)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("model state valid");
                Debug.WriteLine(c);
                return View("RGBInterpolator", c);
            }
            else
            {
                Debug.WriteLine("model state NOT valid");
                return View("RGBInterpolator", c);
            }
            
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
