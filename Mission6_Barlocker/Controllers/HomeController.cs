using Microsoft.AspNetCore.Mvc;
using Mission6_Barlocker.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie input) 
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(input); // Add to the database
                _context.SaveChanges(); // Commit changes to database

                return View("FormConfirmation", input);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(input);
            }
            
        }


        public IActionResult MovieCollection() 
        {
            var Movies = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.CategoryId into categoryGroup
                          from category in categoryGroup.DefaultIfEmpty()
                          select new MovieCategory
                          {
                              Movie = m,
                              Category = category
                          })
                          .ToList();


            return View(Movies);
        }
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();

                return RedirectToAction("MovieCollection");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View("MovieForm", updatedInfo);
            }
            
        }

        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("DeleteConfirmation", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

    }
}
