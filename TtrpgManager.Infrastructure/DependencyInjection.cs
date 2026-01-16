using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TtrpgManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace TtrpgManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TtrpgManagerDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Default")));

        return services;
    }
}
