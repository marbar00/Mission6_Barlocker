using Microsoft.AspNetCore.Mvc;
using Mission6_Barlocker.Models;
using System.Diagnostics;

namespace Mission6_Barlocker.Controllers
{
    public class HomeController : Controller
    {
        private  MovieInputContext _context;

        public HomeController(MovieInputContext temp)
        {
           _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie input) 
        {
            _context.MovieInputs.Add(input); // Add to the database
            _context.SaveChanges(); // Commit changes to database

            return View(input);
        }
    }
}
