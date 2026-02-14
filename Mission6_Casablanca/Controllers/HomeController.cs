using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Casablanca.Models;

namespace Mission6_Casablanca.Controllers
{
    public class HomeController : Controller
    {

        private MovieSubmissionContext _context;
        public HomeController(MovieSubmissionContext temp)
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
            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult AddMovie(MovieSubmission response)
        {
            _context.MovieStockpile.Add(response); // add record to database
            _context.SaveChanges(); // save changes to database
            return View("formSubmitted", response);
        }
    }
}
