using XPike.IoC;

namespace XPike.Configuration.MultiTenant
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeMultiTenantConfiguration(this IDependencyCollection collection) =>
            collection.LoadPackage(new XPike.Configuration.MultiTenant.Package());
    }
}