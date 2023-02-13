namespace Bugtracker_api_net;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}