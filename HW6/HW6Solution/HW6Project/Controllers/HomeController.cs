using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW6Project.Models;
using Microsoft.VisualBasic;

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
            
            //make some default bad artist and put it in a list. send that list to the view and check it for the bad artist.

            if (String.IsNullOrEmpty(q))
            {
                
                return View();            
            }
            else if (q.Length < 2)
            {
                return View();
            }
            else
            {
                return View(db.Artists.Where(a => a.Name.Contains(q)));
            }                       
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
