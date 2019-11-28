namespace XPike.MultiTenant
{
    public interface ITenantContext
    {
        ITenant Tenant { get; }
    }
}