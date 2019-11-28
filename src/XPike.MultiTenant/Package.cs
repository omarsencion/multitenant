using XPike.IoC;

namespace XPike.MultiTenant
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.AddSingletonToCollection<ITenantContextProvider, DefaultTenantContextProvider>();
            dependencyCollection.RegisterSingleton<ITenantContextAccessor, TenantContextAccessor>();
            
            dependencyCollection.RegisterScoped<ITenantContext>(services =>
                services.ResolveDependency<ITenantContextAccessor>().TenantContext);
        }
    }
}