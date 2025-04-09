using SLRPBackend.Model;

namespace SLRPBackend.Service;

public class SessionService : IHostedService, ISessionService
{
    private readonly List<RpSession> rpSessions = new List<RpSession>();
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void CreateSession()
    {
        
    }

    public void EndSession()
    {
        
    }

    public void GetSession()
    {
        
    }
}