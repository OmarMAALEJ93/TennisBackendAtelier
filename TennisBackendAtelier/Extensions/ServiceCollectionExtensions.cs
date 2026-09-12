using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Repositories;
using TennisBackendAtelier.Services;

namespace TennisBackendAtelier.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayerServices(this IServiceCollection services)
    {
        services.AddSingleton<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IPlayerService, PlayerService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        return services;
    }
}
