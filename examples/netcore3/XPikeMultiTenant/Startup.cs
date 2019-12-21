using Example.Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XPike.Configuration;
using XPike.Configuration.MultiTenant;
using XPike.IoC.Microsoft.AspNetCore;
using XPike.Logging.Microsoft.AspNetCore;
using XPike.RequestContext.Http.AspNetCore;
using XPike.Settings.AspNetCore;

//using XPike.IoC.SimpleInjector.AspNetCore;

namespace XPikeMultiTenant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var value = Configuration["XPike:DataStores:MultiTenant:ConnectionConfig"];

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services //.AddXPikeSettings()
                .AddXPikeLogging()
                .AddXPikeSettings()
                .AddXPikeExampleDbContexts()
                .AddXPikeHttpRequestContext()
                .AddXPikeDependencyInjection()
                .AddXPikeMultiTenantExample()
                .AddXPikeMultiTenantConfiguration();
            //                .RegisterSingleton(typeof(ISettings<>), typeof(SettingsLoader<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var provider = app.UseXPikeDependencyInjection()
                .UseXPikeLogging()
                .UseXPikeMultiTenantConfiguration();

            var config = provider.ResolveDependency<IConfigurationService>();
            var value = config.GetValue("XPike.DataStores.MultiTenant.ConnectionConfig");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
        }
    }
}
