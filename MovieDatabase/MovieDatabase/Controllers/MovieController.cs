using MovieDatabase.Models;
using Services;
using DTO = Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        MovieDBService serviceClient = new MovieDBService();
        
        public ActionResult Index(int id = 0)
        {
            var movie = new Movie { ID = id };
            if (id > 0)
            {
                movie = serviceClient.GetMovie(id).ToModel();
                //movie = MockData.Instance.MovieList.Where(c => c.ID == id).FirstOrDefault();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                serviceClient.SubmitMovie(movie.ToDTO());
                return RedirectToAction("Index", "Home");
            }

            return View("Index", movie);
        }

        public ActionResult AddActor(int movieID, int actorID)
        {
            serviceClient.AddActorToMovie(actorID, movieID);

            return Json(new { movieID = movieID, actorID = actorID });
        }

        public ActionResult RemoveActor(int movieID, int actorID)
        {
            serviceClient.RemoveActorFromMovie(actorID, movieID);

            return Json(new { movieID = movieID, actorID = actorID });
        }

        public MovieController()
        {
            //ViewData["GenreList"] = MockData.Instance.GenreList;
            ViewData["GenreList"] = serviceClient.GetGenres().Select(c => c.ToModel()).ToList();

            //ViewData["ActorList"] = MockData.Instance.ActorList;
            ViewData["ActorList"] = serviceClient.GetActors().Select(c => c.ToModel()).ToList();
        }
    }
}