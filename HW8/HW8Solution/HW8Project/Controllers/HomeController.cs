using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW8Project.Models;
using Microsoft.EntityFrameworkCore;

namespace HW8Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HW8DbContext db;

        public HomeController(ILogger<HomeController> logger, HW8DbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddClassesPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClassesPage(AddClassesViewModel vm)
        {
            if (ModelState.IsValid)
            {

                IEnumerable<string> inputList = string.Concat(vm.Input.Where(c => !char.IsWhiteSpace(c))).Split(',');
                //Debug.WriteLine(string.Concat(vm.Input.Where(c => !char.IsWhiteSpace(c))));
                foreach (string s in inputList)
                {
                    Course myCourse = new Course
                    {
                        CourseId = s
                    };
                    Debug.WriteLine(s);
                    if (!db.Courses.Contains(myCourse))
                    {
                        db.Courses.Add(myCourse);
                    }
                }
                //db.Courses.Add(course);
                db.SaveChanges(); 
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddAssignmentPage()
        {
            AddAssignmentPageViewModel myModel = new AddAssignmentPageViewModel
            {
                CourseList = db.Courses,
                KeywordList = db.Keywords
            };
            return View(myModel);
        }

        [HttpPost]
        public IActionResult AddAssignmentPage(AddAssignmentPageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = new Assignment
                {
                    Priority = vm.Priority,
                    DueDate = vm.DueDate,
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Notes = vm.Notes
                };

                db.Assignments.Add(assignment);
                db.SaveChanges();
                return View("AssignmentsTracker", db.Assignments.Where(a => a.Completed == 1).OrderByDescending(a => a.DueDate));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AssignmentsTracker()
        {
            return View(db.Assignments.Where(a => a.Completed == 1).OrderByDescending(a => a.DueDate));
        }

        [HttpGet]
        public IActionResult CourseAssignments(string id)
        {
            Debug.WriteLine("inside /Search/Artist action method");

            //return View(db.Artists.Include(a => a.Albums).ThenInclude(t => t.Tracks).Where(a => a.ArtistId == id));
            return View(db.Assignments.Where(a => a.Completed == 1 && a.CourseId == id).OrderByDescending(a => a.DueDate));
        }


        public IActionResult CompleteAssignment(string data)
        {
            
            Debug.WriteLine("\n\n**********\n" + data + "\n**********\n\n");

            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
