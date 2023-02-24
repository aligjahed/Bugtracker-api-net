using Bugtracker_api_net.Data;

namespace Bugtracker_api_net;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>();
        return services;
    }
}