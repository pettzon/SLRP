using System.Diagnostics;
using Microsoft.Extensions.Options;
using SLRPBackend.Data;

namespace SLRPBackend.Service;

public class DebugAuthService : IAuthService
{
    public event Action<string>? OnAuthorize = delegate { };
    private readonly IOptions<AuthServiceOptions> options;
    
    public DebugAuthService(IOptions<AuthServiceOptions> options)
    {
        this.options = options;
    }

    public Task<bool> Authorize(string token)
    {
        //Authorize right away if using debug token, only for development
        if (token != options.Value.DebugToken) return Task.FromResult(false);
        
        OnAuthorize?.Invoke(token);
        return Task.FromResult(true);
    }
}