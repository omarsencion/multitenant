using Example.Library.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Library
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddXPikeExampleDbContexts(this IServiceCollection services) =>
            services.AddDbContext<ExampleDbContext>();
    }
}