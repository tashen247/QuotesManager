
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Entities
{
    public interface IDataSource
    {
        IQueryable<Mood> moodData { get;  }
        IQueryable<Quote> quoteData { get; }
        void Save();
    }
}
