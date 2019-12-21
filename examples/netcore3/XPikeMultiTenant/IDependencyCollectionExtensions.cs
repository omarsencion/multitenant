using XPike.IoC;

namespace XPikeMultiTenant
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeMultiTenantExample(this IDependencyCollection collection) =>
            collection.LoadPackage(new Package());
    }
}