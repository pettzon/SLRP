using SLRPBackend.Service;

namespace SLRPBackend.Extension;

public static class DependencyExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddHostedService<SessionService>();
        services.AddHostedService<LLMService>();
    }
}