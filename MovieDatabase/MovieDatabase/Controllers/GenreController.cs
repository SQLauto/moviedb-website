using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;
using Services;

namespace MovieDatabase.Controllers
{
    public class GenreController : Controller
    {
        MovieDBService serviceClient = new MovieDBService();
        
        public ActionResult Index(int id = 0)
        {
            var model = new Genre();
            if (id > 0)
            {
                //model = MockData.Instance.GenreList.Where(c => c.ID == id).FirstOrDefault();
                //ViewData["ActorList"] = MockData.Instance.Stats.ActorsInGenre[model.Name];

                model = serviceClient.GetGenre(id).ToModel();
                ViewData["ActorList"] = serviceClient.GetActors(genreID: id).Select(c => c.ToModel()).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitGenre([Bind(Exclude = "ID")] Genre model)
        {
            // Submit the genre
            if (ModelState.IsValid)
            {
                serviceClient.SubmitGenre(model.ToDTO());

                ViewData["ActorList"] = serviceClient.GetActors(genreID: model.ID).Select(c => c.ToModel()).ToList();
                //ViewData["ActorList"] = MockData.Instance.Stats.ActorsInGenre[model.Name];

                return RedirectToAction("Index", "Home");
            }

            return View("Index", model);
        }
    }
}