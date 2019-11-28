using System.Threading.Tasks;
using Example.Library.DbContexts;
using Example.Library.Models;
using Microsoft.EntityFrameworkCore;
using XPike.DataStores;
using XPike.DataStores.EntityFrameworkCore;

namespace Example.Library.DataStores.EntityFramework
{
    public class EntityFrameworkExampleDataStore
        : EntityFrameworkCoreDataStoreBase<ExampleDbContext>,
          IEntityFrameworkExampleDataStore
    {
        protected override string ConnectionString => "Unused";

        public EntityFrameworkExampleDataStore(IEntityFrameworkCoreDataConnectionProvider<ExampleDbContext> provider,
                                               IConnectionStringManager connectionStringManager)
            : base(provider, connectionStringManager)
        {
        }

        public Task<User> GetExampleAsync(int id) =>
            WithContextAsync(x => x.Examples.Include(y => y.ContactInfo)
                .SingleOrDefaultAsync(y => y.Id == id));

        public Task<int?> CreateExampleAsync(User model) =>
            WithContextAsync(async context =>
                             {
                                 context.Examples.Add(model);

                                 return (await context.SaveChangesAsync() > 0) ? model.Id : (int?) null;
                             });

        public Task<bool> DeleteExampleAsync(int id) =>
            WithContextAsync(async context =>
                             {
                                 context.Examples.Remove(await GetExampleAsync(id));
                                 return await context.SaveChangesAsync() > 0;
                             });

        public Task<bool> UpdateExampleAsync(User model) =>
            WithContextAsync(async context =>
                             {
                                 context.Examples.Update(model);
                                 return await context.SaveChangesAsync() > 0;
                             });
    }
}