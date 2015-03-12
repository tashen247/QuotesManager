using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Quotes.Entities;

using System.Web.Security;

namespace Quotes.Web.Migrations
{
    internal sealed class Configuration :DbMigrationsConfiguration<Quotes.Web.Infrastructure.QuotesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infrastructure.QuotesDb context)
        {
            base.Seed(context);
            context.moods.AddOrUpdate(d => d.moodDesc,
                new Mood() { moodDesc = "happy" },
                new Mood() { moodDesc = "motivation" },
                new Mood() { moodDesc = "ambitious" }                
                );

            //if (Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}

            //if (Membership.GetUser("tashen") == null)
            //{
            //    Membership.CreateUser("tashen", "FluffyBunny@1");
            //    Roles.AddUserToRole("tashen","Admin");
            //}
        }
    }
}
