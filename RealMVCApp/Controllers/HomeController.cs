using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealMVCApp.Models;

namespace RealMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext temp) // Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response); //Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        //Need to adjust Controllers below. 
        public IActionResult MovieTable(Application response)
        {
            var applications = _context.Applications//Dbset<application>
                .Include(x => x.Category)
                .OrderBy(x => x.Category);
            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int recordId)
        {
            Application recordToEdit = _context.Applications
                .Single(x => x.MovieFormID == recordId);

            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.MovieFormId = id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application updatedInfo)
        {
            _context.Applications.Remove(updatedInfo);
            _context.SaveChanges();
        }
    }
}
