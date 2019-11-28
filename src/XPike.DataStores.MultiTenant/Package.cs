using XPike.IoC;

namespace XPike.DataStores.MultiTenant
{
    public class Package
        : IDependencyPackage 
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.DataStores.Package());
            dependencyCollection.LoadPackage(new XPike.MultiTenant.Package());

            dependencyCollection.RegisterSingleton<IMultiTenantConnectionStringManager, MultiTenantConnectionStringManager>();
        }
    }
}