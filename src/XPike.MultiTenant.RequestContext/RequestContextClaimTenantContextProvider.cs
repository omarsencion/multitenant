using System;
using XPike.Logging;
using XPike.MultiTenant.Http;
using XPike.RequestContext;

namespace XPike.MultiTenant.RequestContext
{
    public class RequestContextClaimTenantContextProvider
        : IRequestContextClaimTenantContextProvider
    {
        public static string ClaimName { get; set; }

        private readonly IRequestContextAccessor _contextAccessor;
        private readonly ILog<RequestContextClaimTenantContextProvider> _logger;

        public RequestContextClaimTenantContextProvider(IRequestContextAccessor contextAccessor, ILog<RequestContextClaimTenantContextProvider> logger)
        {
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public ITenantContext CreateContext()
        {
            string tenantId = null;

            try
            {
                if ((_contextAccessor.RequestContext?.Claims?.TryGetValue(ClaimName, out tenantId) ?? false) &&
                    !string.IsNullOrWhiteSpace(tenantId))
                    return new TenantContext(new Tenant(tenantId));
            }
            catch (Exception ex)
            {
                _logger.Trace($"Failed to retrieve Tenant Context from Request Context claim '{ClaimName}': {ex.Message} ({ex.GetType()})");
            }

            return null;
        }
    }
}