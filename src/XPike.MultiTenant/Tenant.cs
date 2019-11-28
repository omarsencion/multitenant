namespace XPike.MultiTenant
{
    public class Tenant
        : ITenant
    {
        public string UniqueId { get; }

        public Tenant(string uniqueId)
        {
            UniqueId = uniqueId;
        }
    }
}