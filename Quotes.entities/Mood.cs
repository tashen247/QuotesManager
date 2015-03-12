
namespace Quotes.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mood
    {
        public Mood()
        {
            quotes = new HashSet<Quote>();
        }
        public int moodID { get; set; }
        public string moodDesc { get; set; }

        public virtual ICollection<Quote>  quotes { get; set; }


    }
}
