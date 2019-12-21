using System;
using System.Collections.Generic;
using XPike.MultiTenant;
using XPike.Settings.Basic;
using XPike.Settings.Providers;

namespace XPike.Settings.MultiTenant
{
    public class MultiTenantSettingsService
        : SettingsService,
          IMultiTenantSettingsService
    {
        private readonly ITenantContextAccessor _contextAccessor;

        public MultiTenantSettingsService(IEnumerable<ISettingsProvider> providers, ITenantContextAccessor contextAccessor)
            : base(providers)
        {
            _contextAccessor = contextAccessor;
        }

        public override ISettings<TSettings> GetSettings<TSettings>(string key)
        {
            ISettings<TSettings> settings = null;

            try
            {
                var context = _contextAccessor.TenantContext;
                if (!string.IsNullOrWhiteSpace(context?.Tenant?.UniqueId))
                    settings = base.GetSettings<TSettings>($"{context.Tenant.UniqueId}::{key}");
            }
            catch (Exception)
            {
            }

            return settings?.Value == null ? base.GetSettings<TSettings>(key) : settings;
        }

        public override ISettings<TSettings> GetSettingsOrDefault<TSettings>(string key, TSettings defaultValue = null)
        {
            ISettings<TSettings> settings = null;

            try
            {
                var context = _contextAccessor.TenantContext;
                if (!string.IsNullOrWhiteSpace(context?.Tenant?.UniqueId))
                    settings = base.GetSettingsOrDefault<TSettings>($"{context.Tenant.UniqueId}::{key}", null);
            }
            catch (Exception)
            {
            }

            return settings?.Value == null ? base.GetSettingsOrDefault(key, defaultValue) : settings;
        }
    }
}