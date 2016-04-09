using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Model = MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class StatisticsController : Controller
    {
        MovieDBService serviceClient = new MovieDBService();
        public ActionResult Index()
        {
            var stats = new Model.Statistics();

            stats = serviceClient.GetStatistics().ToModel();
            //stats = MockData.Instance.Stats;

            return View(stats);
        }
    }
}