using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ngclopedia.Application.Interfaces.Persistence;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Infrastructure.Common;
using Ngclopedia.Infrastructure.ConnectionString;
using Ngclopedia.Infrastructure.Persistence.Context;
using Ngclopedia.Infrastructure.Persistence.Repository;
using Serilog;

namespace Ngclopedia.Infrastructure.Persistence;

internal static class Startup
{
    private static readonly ILogger _logger = Log.ForContext(typeof(Startup));

    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(nameof(DatabaseSettings))
            .PostConfigure(databaseSettings =>
            {
                _logger.Information("Current DB Provider: {dbProvider}", databaseSettings.DBProvider);
            })
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services
            .AddDbContext<ApplicationDbContext>((p, m) =>
            {
                var databaseSettings = p.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                m.UseDatabase(databaseSettings.DBProvider, databaseSettings.ConnectionString);
            })
            .AddTransient<IConnectionStringSecurer, ConnectionStringSecurer>()
            .AddTransient<IConnectionStringValidator, ConnectionStringValidator>()
            .AddRepositories();
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider,
        string connectionString)
    {
        switch (dbProvider.ToLowerInvariant())
        {
            case DbProviderKeys.Npgsql:
                return builder.UseNpgsql(connectionString);

            default:
                throw new InvalidOperationException($"DB Provider {dbProvider} is not supported.");
        }
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}