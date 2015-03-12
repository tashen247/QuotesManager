using StructureMap;
using Quotes.Entities;
using Quotes.Web.Infrastructure;
namespace Quotes.Web {
    public static class IoC {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                x.For<IDataSource>().Use<QuotesDb>();
            });
            return ObjectFactory.Container;
        }
    }
}