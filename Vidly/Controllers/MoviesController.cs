using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new List<Movie>
            {
                new Movie{Name = "Shrek" }
            };

            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // /movies/edit?id=1
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // movies/released/{year}/{month}

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        // /movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        public ActionResult Index()
        {

            var movies = GetMovies();

            return View(movies);
        }
    }
}