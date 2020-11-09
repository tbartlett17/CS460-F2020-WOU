using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW6Project.Models;

namespace HW6Project.Controllers
{
    public class HomeController : Controller
    {
        private HW6DBContext db;

        public HomeController(HW6DBContext db)
        {
            this.db = db;
        }
      

        public IActionResult Index(string q)
        {
            Debug.WriteLine("inside /Search/Artist action method");



            // if (input.isNullorEmpty) {}

            return View(db.Artists.Where(a => a.Name.Contains(q)));
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
