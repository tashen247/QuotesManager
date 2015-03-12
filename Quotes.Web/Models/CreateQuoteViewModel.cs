using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Quotes.Web.Infrastructure;
using Quotes.Entities;
using System.Web.Mvc;

namespace Quotes.Web.Models
{
    public class CreateQuoteViewModel
    {
        [Required]      
        public string quoteDesc { get; set; }
        public int moodID { get; set; }
        [Required]  
        public string source { get; set; }

        public SelectList moodTypes { get; set; }

        //public IList<Mood> GetMoods()
        //{
        //    //var context = new QuotesDb();
        //    //list (from c in context.moods
        //    //                         select c).ToList();
        //    //return moodTypes;

        //}
    }
}