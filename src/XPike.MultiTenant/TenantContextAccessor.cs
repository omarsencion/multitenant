using System;
using System.Collections.Generic;
using System.Linq;
using XPike.Logging;
#if NETSTD
using System.Threading;
#elif NETFX
using System.Runtime.Remoting.Messaging;
#endif

namespace XPike.MultiTenant
{
    public class TenantContextAccessor
        : ITenantContextAccessor
    {
#if NETSTD
        private static readonly AsyncLocal<ITenantContext> _localizer = new AsyncLocal<ITenantContext>();
#endif

        private readonly ILog<TenantContextAccessor> _logger;
        private readonly IList<ITenantContextProvider> _providers;

#if NETSTD
        public ITenantContext TenantContext =>
            _localizer.Value ?? (_localizer.Value = CreateContext());
#elif NETFX
        public ITenantContext TenantContext
        {
            get
            {
                var context = (ITenantContext) CallContext.LogicalGetData(GetType().ToString());

                if (context == null)
                {
                    context = CreateContext();
                    CallContext.LogicalSetData(GetType().ToString(), context);
                }

                return context;
            }
        }
#endif

        public TenantContextAccessor(IEnumerable<ITenantContextProvider> providers, ILog<TenantContextAccessor> logger)
        {
            _logger = logger;
            _providers = providers.Reverse().ToList();
        }

        protected ITenantContext CreateContext()
        {
            ITenantContext context = null;

            foreach (var provider in _providers)
            {
                try
                {
                    context = provider.CreateContext() ?? context;

                    if ((context?.Tenant?.UniqueId ?? DefaultTenantContextProvider.DEFAULT_CONTEXT_ID) !=
                        DefaultTenantContextProvider.DEFAULT_CONTEXT_ID)
                        return context;
                }
                catch (Exception ex)
                {
                    _logger.Trace($"Failed to load Tenant Context from Provider {provider.GetType()}: {ex.Message} ({ex.GetType()})");
                }
            }

            if (context == null)
                _logger.Warn($"Failed to load Tenant Context from any Provider!");

            return context;
        }
    }
}