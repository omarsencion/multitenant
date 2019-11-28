using Example.Library.DbContexts;
using XPike.DataStores.EntityFrameworkCore;

namespace Example.Library.DataStores.EntityFramework
{
    public interface IEntityFrameworkExampleDataStore
        : IEntityFrameworkCoreDataStore<ExampleDbContext>,
          IExampleDataStore
    {
    }
}