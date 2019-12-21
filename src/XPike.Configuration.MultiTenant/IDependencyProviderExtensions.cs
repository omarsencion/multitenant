using XPike.IoC;

namespace XPike.Configuration.MultiTenant
{
    public static class IDependencyProviderExtensions
    {
        public static IDependencyProvider UseXPikeMultiTenantConfiguration(this IDependencyProvider provider)
        {
            provider.ResolveDependency<IConfigurationService>()
                .AddToPipeline(provider.ResolveDependency<IMultiTenantConfigurationPipe>());

            return provider;
        }
    }
}