using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quotes.Web.Infrastructure;
using Quotes.Entities;

namespace Quotes.Web.Models
{
    public class MoodGroupViewModel
    {
        
        public MoodGroupViewModel()
        {
            var db = new QuotesDb();
            moodData = db.moods;
        }
        public int Type { get; set; }
        public int Count { get; set; }

        public IQueryable<Mood> moodData { get; set; }
    
    }
}