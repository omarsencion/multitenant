namespace XPike.MultiTenant
{
    public class DefaultTenantContextProvider
        : ITenantContextProvider
    {
        public const string DEFAULT_CONTEXT_ID = "DEFAULT";

        public ITenantContext CreateContext() =>
            new TenantContext(new Tenant(DEFAULT_CONTEXT_ID));
    }
}