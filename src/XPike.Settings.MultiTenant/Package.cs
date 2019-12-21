using XPike.IoC;

namespace XPike.Settings.MultiTenant
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.Settings.Package());
            dependencyCollection.LoadPackage(new XPike.MultiTenant.Package());

            dependencyCollection.RegisterSingleton<IMultiTenantSettingsService, MultiTenantSettingsService>();
            dependencyCollection.RegisterSingleton<ISettingsService>(services => services.ResolveDependency<IMultiTenantSettingsService>());
        }
    }
}