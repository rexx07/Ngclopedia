using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ngclopedia.Application.Caching;

namespace Ngclopedia.Infrastructure.Caching;

internal static class Startup
{
    internal static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration config)
    {
        services.AddMemoryCache();
        services.AddTransient<ICacheService, LocalCacheService>();
        services.AddResponseCaching()
            .AddHttpCacheHeader();

        return services;
    }

    internal static IApplicationBuilder UseCaching(this IApplicationBuilder builder)
    {
        return builder.UseResponseCaching();
    }

    internal static IServiceCollection AddHttpCacheHeader(this IServiceCollection services) =>
        services.AddHttpCacheHeaders(expirationOpt =>
            {
                expirationOpt.MaxAge = 65;
                expirationOpt.CacheLocation = CacheLocation.Private;
            },
            validationOpt => { validationOpt.MustRevalidate = true; });
}