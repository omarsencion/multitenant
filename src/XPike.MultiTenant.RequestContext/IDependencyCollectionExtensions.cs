using XPike.IoC;
using XPike.MultiTenant.Http;

namespace XPike.MultiTenant.RequestContext
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeRequestContextTenantHeader(this IDependencyCollection collection, string headerName)
        {
            collection.LoadPackage(new XPike.MultiTenant.RequestContext.Package());
            
            RequestContextHeaderTenantContextProvider.HeaderName = headerName;

            collection.AddSingletonToCollection<ITenantContextProvider, IRequestContextHeaderTenantContextProvider>(container =>
                container.ResolveDependency<IRequestContextHeaderTenantContextProvider>());

            return collection;
        }

        public static IDependencyCollection AddXPikeRequestContextTenantClaim(this IDependencyCollection collection, string claimName)
        {
            collection.LoadPackage(new XPike.MultiTenant.RequestContext.Package());

            RequestContextClaimTenantContextProvider.ClaimName = claimName;

            collection.AddSingletonToCollection<ITenantContextProvider, IRequestContextClaimTenantContextProvider>(container =>
                container.ResolveDependency<IRequestContextClaimTenantContextProvider>());

            return collection;
        }
    }
}