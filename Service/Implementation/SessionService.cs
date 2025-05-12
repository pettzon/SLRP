using System.Diagnostics;
using SLRPBackend.Model;

namespace SLRPBackend.Service;

public sealed class SessionService : ISessionService
{
    private readonly IDBService dbService;
    private readonly ILLMService llmService;
    private readonly IAuthService authService;
    
    private readonly HashSet<RpClient> clientSessions = new HashSet<RpClient>();

    public SessionService(IDBService dbService, ILLMService llmService, IAuthService authService)
    {
        this.dbService = dbService;
        this.llmService = llmService;
        this.authService = authService;

        authService.OnAuthorize += CreateSession;
    }
    
    private void CreateSession(string uuid)
    {
        if (clientSessions.Any(client => client.uuid == uuid)) return;
        clientSessions.Add(new RpClient(uuid));
        
        Debug.WriteLine($"Authorized and created session for {uuid}");
    }

    public void EndSession()
    {
        throw new NotImplementedException();
    }

    public async Task<RpClient> GetSession(string uuid)
    {
        RpClient? result = await Task.Run(() =>
        {
            foreach (RpClient client in clientSessions)
            {
                if (client.uuid != uuid) continue;

                return client;
            }

            return null;
        });

        return result;
    }

    public async Task<bool> SessionExists(string uuid)
    {
        bool result = await Task.Run(() =>
        {
            return clientSessions.Any(client => client.uuid == uuid);
        });

        return result;
    }

    public Task PostSession(SLRPRequest request)
    {
        RpClient? client = clientSessions.FirstOrDefault(client => client.uuid == request.uuid);
        return Task.CompletedTask;
    }
}