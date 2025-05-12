using SLRPBackend.Service;

namespace SLRPBackend.Extension;

public static class DependencyExtension
{
    public static void AddExtraServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthService, DebugAuthService>(); // Debug auth
        services.AddSingleton<ISessionService, SessionService>();
        services.AddSingleton<IDBService, DBService>();
        services.AddSingleton<ILLMService, LLMService>();

        // services.AddHostedService<SessionService>();
        // services.AddHostedService<LLMService>();
    }
}