using Example.Library.DataStores;
using Example.Library.DataStores.EntityFramework;
using Example.Library.DataStores.MySql;
using XPike.IoC;

namespace Example.Library
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.DataStores.EntityFrameworkCore.Package());

            dependencyCollection.RegisterScoped<IEntityFrameworkExampleDataStore, EntityFrameworkExampleDataStore>();
            
            dependencyCollection.RegisterSingleton<IMySqlExampleDataStore, MySqlExampleDataStore>();
            dependencyCollection.RegisterSingleton<IExampleDataStore>(container => container.ResolveDependency<IMySqlExampleDataStore>());
        }
    }
}