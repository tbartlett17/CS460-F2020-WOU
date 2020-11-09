using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HW6Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HW6Project.Controllers
{
    public class SearchController : Controller
    {
        private HW6DBContext db;

        public SearchController(HW6DBContext db)
        {
            this.db = db;
        }
        
           

        [HttpGet]
        public IActionResult Artist(int? id)
        {
            Debug.WriteLine("inside /Search/Artist action method");

            return View(db.Artists.Include(a => a.Albums).ThenInclude(t => t.Tracks).Where(a => a.ArtistId == id));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
