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
            // Grabbing movies context and setting to list 
            var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Grabbing the Record to edit via the Id
            Movies recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            // Setting the viewbag to include the categories
            ViewBag.Category = _context.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        //Posting the updates to the edited movie pane
        public IActionResult Edit(Movies updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        // Getting the Delete confirmation page
        public IActionResult Delete(int id)
        {
            Movies recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        //Submitting the delete statement.
        public IActionResult Delete(Movies updatedInfo)
        {
            _context.Movies.Remove(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
