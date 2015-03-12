using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Entities;

namespace Quotes.Web.Controllers
{
    public class MoodController : Controller
    {
        private readonly IDataSource _db;

        public MoodController(IDataSource db)
        {
             _db=db;
        }
        public ActionResult Detail(int id)
        {
            var model = _db.moodData.Single(q => q.moodID == id);
            return View(model);
            return View();
        }
        public ActionResult List(int id)
        {
            //var model = db.moodData.Single(x => x.moodID == id);
            //ViewBag(model);
            //var allQuotes = db.quoteData.Select(q => q.moodID == id);
            var model = _db.moodData.Select(q => q.moodID == id);
            return View(model);
        }


    }
}
