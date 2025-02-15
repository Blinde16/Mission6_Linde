using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RealMVCApp.Models;

namespace RealMVCApp.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }
    }
}
