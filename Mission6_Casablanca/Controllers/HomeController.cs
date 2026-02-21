using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission6_Casablanca.Models;
using System.Diagnostics;

namespace Mission6_Casablanca.Controllers
{
    public class HomeController : Controller
    {

        private MovieSubmissionContext _context;
        public HomeController(MovieSubmissionContext temp) // constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetKnow()
        {
            return View("GetToKnow");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            // Get categories from the database and create a SelectList
            // The SelectList takes the value field (CategoryId) and the text field (CategoryName)
            ViewBag.categories = new SelectList(
                _context.Categories
                        .OrderBy(c => c.CategoryName)
                        .ToList(),
                "CategoryId",       // value field
                "CategoryName"      // text field
            );

            // Pass a new Movies object to the view
            return View("AddMovie", new Movies());
        }



        [HttpPost]
        public IActionResult AddMovie(Movies response)
        {
            if (ModelState.IsValid) // if form data is valid, add record to database
            {
                _context.Movies.Add(response); // add record to database
                _context.SaveChanges(); // save changes to database
                return View("formSubmitted", response);
            }

            else
            {
                ViewBag.categories = new SelectList(
                    _context.Categories
                            .OrderBy(x => x.CategoryName)
                            .ToList(),
                    "CategoryId",
                    "CategoryName",
                    response.CategoryId   // preserves selected value
                );

                return View("AddMovie", response);
            }
        }


        public IActionResult WatchList()
        {
            // linq query to get movies from database and order by year
            var newMovie = _context.Movies
                .OrderBy(x => x.Year).ToList(); // order movies by year 
            return View(newMovie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id); // get movie with id of selected id

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                 .Select(c => new SelectListItem
                 {
                     Value = c.CategoryId.ToString(),
                     Text = c.CategoryName
                 })
                .ToList(); // get list of movies from database


            return View("AddMovie", movieToEdit);
        }


        [HttpPost]
        public IActionResult Edit(Movies response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(response);
                _context.SaveChanges();
                return RedirectToAction("WatchList");
            }
            else
            {
                ViewBag.categories = new SelectList(
                    _context.Categories.OrderBy(x => x.CategoryName).ToList(),
                    "CategoryId",
                    "CategoryName",
                    response.CategoryId
                );
                return View("AddMovie", response);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id); // get movie with id of selected id

            ViewBag.categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList(); // get list of movies from database

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies response)
        {
            _context.Movies.Remove(response); // remove record from database
            _context.SaveChanges(); // save changes to database
            return RedirectToAction("WatchList");
        }
    }
}
