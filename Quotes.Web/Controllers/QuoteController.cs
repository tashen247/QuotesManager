using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Web.Models;
using Quotes.Entities;
using Quotes.Web.Infrastructure;
namespace Quotes.Web.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IDataSource _db;       
        public QuoteController(IDataSource db  )
        {
             _db = db;
        }
        [HttpGet]
        public ActionResult Create(int quoteid)
        {
            var model = new CreateQuoteViewModel();
            model.moodID = quoteid;
            var context = new QuotesDb();
            List<Mood> moodList = (from c in _db.moodData
                 select c).ToList();
            //return moodTypes;
            ViewBag.ListOfMoods =  new SelectList(moodList, "moodID", "moodDesc");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateQuoteViewModel quote)
        { 
            if(ModelState.IsValid)
            {
                var mood = _db.moodData.Single(d => d.moodID == quote.moodID);                
                var newQuote = new Quote();
                newQuote.quoteDesc = quote.quoteDesc;
                newQuote.source = quote.source;
                mood.quotes.Add(newQuote);
                _db.Save();

                RedirectToAction("detail", "Mood", new { id = quote.moodID });
                
            }

                return View(quote);

        }

        public ActionResult Index()
        {
            var allQuotes = _db.quoteData;
            return View(allQuotes);
        }

        //public IList<Mood> GetMood()
        //{
        //    CreateQuoteViewModel cqvm = new CreateQuoteViewModel();
        //    return cqvm.GetMoods();
        //}
    }
}
