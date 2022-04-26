using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        // GET: /api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            var moviesDto = _context.Movies.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return moviesDto;
        }

        [HttpGet]
        //GET: /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        //POST: /api/movies
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            _context.Movies.Add(movie);
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // PUT: /api/movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            movieInDb.Name = movieDTO.Name == null ? movieInDb.Name : movieDTO.Name;
            movieInDb.GenreId = (byte)(movieDTO.GenreId != 0 ? movieInDb.GenreId : movieDTO.GenreId);
            movieInDb.ReleaseDate = (DateTime)(movieDTO.ReleaseDate == null ? movieInDb.ReleaseDate : movieDTO.ReleaseDate);
            movieInDb.NumberInStock = (byte)(movieDTO.NumberInStock != 0 ? movieInDb.NumberInStock : movieDTO.NumberInStock);

            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        // DELETE: /api/movies/id
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return Json(new {ResponseMessage = "Movie Deleted"});

        }
    }
}
