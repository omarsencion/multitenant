using XPike.IoC;

namespace XPike.Settings.MultiTenant
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeMultiTenantSettings(this IDependencyCollection collection) =>
             collection.LoadPackage(new XPike.Settings.MultiTenant.Package());
    }
}