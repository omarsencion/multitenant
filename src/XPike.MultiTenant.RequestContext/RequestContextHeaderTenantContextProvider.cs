using System;
using XPike.Logging;
using XPike.RequestContext;

namespace XPike.MultiTenant.RequestContext
{
    public class RequestContextHeaderTenantContextProvider
        : IRequestContextHeaderTenantContextProvider
    {
        public static string HeaderName { get; set; }

        private readonly IRequestContextAccessor _requestContextAccessor;
        private readonly ILog<RequestContextHeaderTenantContextProvider> _logger;

        public RequestContextHeaderTenantContextProvider(IRequestContextAccessor requestContextAccessor, ILog<RequestContextHeaderTenantContextProvider> logger)
        {
            _requestContextAccessor = requestContextAccessor;
            _logger = logger;
        }

        public ITenantContext CreateContext()
        {
            string tenantId = null;

            try
            {
                if ((_requestContextAccessor.RequestContext?.Headers?.TryGetValue(HeaderName, out tenantId) ?? false) && 
                    !string.IsNullOrWhiteSpace(tenantId))
                    return new TenantContext(new Tenant(tenantId));
            }
            catch (Exception ex)
            {
                _logger.Trace($"Failed to retrieve Tenant Context from Request Context header '{HeaderName}': {ex.Message} ({ex.GetType()})");
            }

            return null;
        }
    }
}