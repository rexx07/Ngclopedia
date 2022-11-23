namespace Ngclopedia.WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => { });
    }

    public static void ConfigureHttpsRedirection(this IServiceCollection services)
    {
        services.AddHttpsRedirection(opts => { opts.HttpsPort = 44350; });
    }
}