using System;
using System.Threading.Tasks;
using XPike.MultiTenant;

namespace XPike.Configuration.MultiTenant
{
    public class MultiTenantConfigurationPipe
        : IMultiTenantConfigurationPipe
    {
        private readonly ITenantContextAccessor _contextAccessor;

        public MultiTenantConfigurationPipe(ITenantContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected string GetTenantId()
        {
            try
            {
                var tenantId = _contextAccessor.TenantContext?.Tenant?.UniqueId;
                return string.IsNullOrWhiteSpace(tenantId) ? null : tenantId;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public string PipelineGet(string key, Func<string, string> next)
        {
            var tenantId = GetTenantId();

            if (tenantId != null)
            {
                try
                {
                    var value = next($"{tenantId}.{key}");

                    if (value != null)
                        return value;
                }
                catch (Exception)
                {
                }
            }

            return next(key);
        }

        public async Task<string> PipelineGetAsync(string key, Func<string, Task<string>> next)
        {
            var tenantId = GetTenantId();

            if (tenantId != null)
            {
                try
                {
                    var value = await next($"{tenantId}.{key}");

                    if (value != null)
                        return value;
                }
                catch (Exception)
                {
                }
            }

            return await next(key);
        }

        public T PipelineGet<T>(string key, Func<string, T> next)
        {
            var tenantId = GetTenantId();

            if (tenantId != null)
            {
                try
                {
                    var value = next($"{tenantId}.{key}");

                    if (value != null)
                        return value;
                }
                catch (Exception)
                {
                }
            }

            return next(key);
        }

        public Task<T> PipelineGetAsync<T>(string key, Func<string, Task<T>> next)
        {
            var tenantId = GetTenantId();

            if (tenantId != null)
            {
                try
                {
                    var value = next($"{tenantId}.{key}");

                    if (value != null)
                        return value;
                }
                catch (Exception)
                {
                }
            }

            return next(key);
        }
    }
}