using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Linq;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /movies
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int Id) {
            var movies = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == Id);
            return View(movies);
        }
    }
}