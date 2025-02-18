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
            ViewBag.Category = _context.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movies response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        //Need to adjust Controllers below. 
        public IActionResult MovieTable()
        {
            var movies = _context.Movies //Dbset<Movies>
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int recordId)
        {
            Movies recordToEdit = _context.Movies
                .Single(x => x.MovieId == recordId);

            ViewBag.Category = _context.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        public IActionResult Delete(int recordId)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == recordId);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies updatedInfo)
        {
            _context.Movies.Remove(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
