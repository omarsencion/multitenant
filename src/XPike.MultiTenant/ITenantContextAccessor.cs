namespace XPike.MultiTenant
{
    public interface ITenantContextAccessor
    {
        ITenantContext TenantContext { get; }
    }
}