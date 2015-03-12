using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Entities;
using Quotes.Web.Models;

namespace Quotes.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDataSource _db;

        public HomeController(IDataSource db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            var allMoods = _db.moodData;
            ViewBag.count = _db.moodData.Count();


            var moodsGroup = _db.moodData
              .GroupBy(d => d.moodID)
              .Select(d => new MoodGroupViewModel
              {    
                  Type = d.Key,
                  Count = d.Count()
              }).ToList();

            
            return View(allMoods);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
