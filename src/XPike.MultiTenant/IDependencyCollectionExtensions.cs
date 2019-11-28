using XPike.IoC;

namespace XPike.MultiTenant
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeMultiTenant(this IDependencyCollection collection) =>
            collection.LoadPackage(new XPike.MultiTenant.Package());
    }
}