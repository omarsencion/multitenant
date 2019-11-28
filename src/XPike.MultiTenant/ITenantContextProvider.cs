namespace XPike.MultiTenant
{
    public interface ITenantContextProvider
    {
        ITenantContext CreateContext();
    }
}