using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using XPike.Configuration.Microsoft.AspNetCore;
using XPike.Logging.Microsoft.AspNetCore;

namespace XPikeDataStores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(builder => { builder.UseXPikeLogging(); })
                .AddXPikeConfiguration(config => { })
                .UseStartup<Startup>();
    }
}
