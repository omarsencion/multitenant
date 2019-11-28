using XPike.IoC;

namespace XPike.DataStores.MultiTenant
{
    public static class IDependencyCollectionExtensions
    {
        public static IDependencyCollection AddXPikeMultiTenantDataStores(this IDependencyCollection collection)
        {
            collection.LoadPackage(new XPike.DataStores.MultiTenant.Package());
            return collection;
        }

        public static IDependencyCollection UseXPikeMultiTenantDataStoresByDefault(this IDependencyCollection collection)
        {
            collection.AddXPikeMultiTenantDataStores();

            collection.RegisterSingleton<IConnectionStringManager>(container =>
                container.ResolveDependency<IMultiTenantConnectionStringManager>());

            return collection;
        }
    }
}