namespace XPike.MultiTenant
{
    public class TenantContext
        : ITenantContext
    {
        public ITenant Tenant { get; }

        public TenantContext(ITenant tenant)
        {
            Tenant = tenant;
        }
    }
}