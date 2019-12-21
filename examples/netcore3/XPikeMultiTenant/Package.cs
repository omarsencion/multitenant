using Example.Library;
using XPike.DataStores.MultiTenant;
using XPike.IoC;
using XPike.MultiTenant.RequestContext;

namespace XPikeMultiTenant
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.AddExampleLibrary();
            dependencyCollection.LoadPackage(new Example.Library.Package());
            dependencyCollection.LoadPackage(new XPike.DataStores.MySql.Pomelo.Package());

            dependencyCollection.AddXPikeMultiTenantDataStores()
                .AddXPikeRequestContextTenantHeader("X-XPike-Tenant-Id");
        }
    }
}