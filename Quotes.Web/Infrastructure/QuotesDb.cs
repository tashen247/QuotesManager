using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Quotes.Entities;
//using Microsoft.AspNet.Identity.EntityFramework;
using Quotes.Web.Models;


namespace Quotes.Web.Infrastructure
{
    public class QuotesDb : DbContext, IDataSource
    {
        public QuotesDb():base("DefaultConnection")
        {
            //moods = new Mood[]();
            //quotes = new IQueryable<Quote>();
        }

        public DbSet<Mood> moods { get; set; }
        public DbSet<Quote> quotes { get; set; }

        void IDataSource.Save()
        {
            SaveChanges();
        }


        IQueryable<Mood> IDataSource.moodData
        {
           get{ return moods;}
        }

        IQueryable<Quote> IDataSource.quoteData
        {
            get { return quotes; }
        }        


    }
}