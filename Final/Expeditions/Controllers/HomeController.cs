using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpeditionsDbContext _context;

        public HomeController(ILogger<HomeController> logger, ExpeditionsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Peaks.Include(e => e.Expeditions).OrderByDescending(p => p.Height).Take(15));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FetchStats()
        {
            // need to return total # of expeditons, total number of peaks, number of climbed peaks

            int totalNumExps = _context.Expeditions.Count();
            int totalNumPeaks = _context.Peaks.Count();
            int numPeaksClimbed = _context.Peaks.Where(p => p.ClimbingStatus == true).Count();

            string stats = "{ \"numExpeditions\": " + totalNumExps + ", \"numPeaks\": " + totalNumPeaks + ", \"numClimbs\": " + numPeaksClimbed + "}" ;

            myObj thing = new myObj(totalNumExps, totalNumPeaks, numPeaksClimbed);

            //string stats = JsonSerializer.Serialize(thing);

            return Json(stats) ;
        }

        struct myObj
        {
            public int totalNumExps;
            public int totalNumPeaks;
            public int numPeaksClimbed;
        
            public myObj(int totalNumExps, int totalNumPeaks, int numPeaksClimbed)
            {
                this.totalNumExps = totalNumExps;
                this.totalNumPeaks = totalNumPeaks;
                this.numPeaksClimbed = numPeaksClimbed;
            }
        }
    }
}
