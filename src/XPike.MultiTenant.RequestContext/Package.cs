using XPike.IoC;
using XPike.MultiTenant.Http;

namespace XPike.MultiTenant.RequestContext
{
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencyCollection)
        {
            dependencyCollection.LoadPackage(new XPike.MultiTenant.Package());
 
            dependencyCollection.RegisterSingleton<IRequestContextHeaderTenantContextProvider, RequestContextHeaderTenantContextProvider>();
            dependencyCollection.RegisterSingleton<IRequestContextClaimTenantContextProvider, RequestContextClaimTenantContextProvider>();

            //dependencyCollection.AddSingletonToCollection<ITenantContextProvider, IRequestContextHeaderTenantContextProvider>(container =>
            //        container.ResolveDependency<IRequestContextHeaderTenantContextProvider>());

            //dependencyCollection.AddSingletonToCollection<ITenantContextProvider, IRequestContextHeaderTenantContextProvider>(container =>
            //    container.ResolveDependency<IRequestContextHeaderTenantContextProvider>());
        }
    }
}