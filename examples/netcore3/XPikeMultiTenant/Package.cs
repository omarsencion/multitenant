using Example.Library;
using XPike.MultiTenant.RequestContext;
using XPike.DataStores.MultiTenant;
using XPike.IoC;

namespace XPikeDataStores
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.Configuration.Microsoft.Package());

            dependencyCollection.AddExampleLibrary();
            dependencyCollection.LoadPackage(new Example.Library.Package());
            dependencyCollection.LoadPackage(new XPike.DataStores.MySql.Pomelo.Package());

            dependencyCollection.AddXPikeMultiTenantDataStores()
                .AddXPikeRequestContextTenantHeader("X-XPike-Tenant-Id");
        }
    }
}