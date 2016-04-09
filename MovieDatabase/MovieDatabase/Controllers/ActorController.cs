using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Model = MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class ActorController : Controller
    {
        MovieDBService serviceClient = new MovieDBService();

        public ActionResult Index(int id = 0)
        {
            var model = new Model.Actor();
            if (id > 0)
            {
                model = serviceClient.GetActor(id).ToModel();
                //model = MockData.Instance.ActorList.Where(c => c.ID == id).FirstOrDefault();
            }

            return View(model);
        }

        public ActionResult SubmitActor([Bind(Exclude = "ID")] Model.Actor model)
        {
            if (ModelState.IsValid)
            {
                serviceClient.SubmitActor(model.ToDTO());
                return RedirectToAction("Index", "Home");
            }

            return View("Index", model);
        }
    }
}