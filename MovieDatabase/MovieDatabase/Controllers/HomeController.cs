using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;
using Services;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        MovieDBService serviceClient = new MovieDBService();
        public ActionResult Index()
        {
            //var movieList = MockData.Instance.MovieList;
            var movieList = serviceClient.GetMovies().Select(c => c.ToModel()).ToList();

            return View(movieList);
        }
    }
}