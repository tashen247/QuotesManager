
namespace Quotes.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quote
    {
        public Quote()
        {

        }
        public virtual int quoteID { get; set; }
        public virtual string quoteDesc { get; set; }
        public virtual Nullable<int> moodID { get; set; }
        public virtual string source { get; set; }

        //public virtual ICollection<Mood> moods { get; set; }
    }
}
