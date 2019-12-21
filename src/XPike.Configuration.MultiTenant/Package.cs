using XPike.IoC;

namespace XPike.Configuration.MultiTenant
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.MultiTenant.Package());

            dependencyCollection.RegisterSingleton<IMultiTenantConfigurationPipe, MultiTenantConfigurationPipe>();
        }
    }
}