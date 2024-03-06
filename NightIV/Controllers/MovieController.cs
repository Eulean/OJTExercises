using NightIV.Context;
using NightIV.Models;
using NightIV.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightIV.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        [Route("Movie")]
        public ActionResult Movie()
        {
            var movies = _context.Movies.ToList();
         /*   {
                new Movie {Id=1,Name="DeadPool"},
                new Movie {Id=2,Name="Confu Panda"}
            };
            var modelView = new MovieView
            {
                Movie = movies
            };*/
            return View(movies);
        }

        [Route("Movie/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c=> c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);

           /* if(movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }*/
        }

        /*private Movie GetMovieById(int id)
        {
            var movies = new List<Movie>
            {
                new Movie {Id=1,Name="DeadPool"},
                new Movie {Id=2,Name="Confu Panda"}
            };
            return movies.FirstOrDefault(M =>  M.Id == id);
        }*/

    }
}