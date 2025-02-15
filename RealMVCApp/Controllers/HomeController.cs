using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    }
}
