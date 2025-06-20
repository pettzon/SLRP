using System.Diagnostics;
using SLRPBackend.Model;
using SLRPBackend.Model.LLM;

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

    public async Task<RpClient> GetClientSession(string uuid)
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

    public async Task<RpSession> GetRpSession(RpClient client, string receiverId)
    {
        RpSession? result = await Task.Run(() =>
        {
            foreach (RpSession rpSession in client.rpSessions)
            {
                if (rpSession.clientId == receiverId)
                {
                    return rpSession;
                }
            }

            return null;
        });

        return result;
    }

    public async Task<bool> ClientSessionExists(string uuid)
    {
        bool result = await Task.Run(() =>
        {
            return clientSessions.Any(client => client.uuid == uuid);
        });

        return result;
    }
    
    public async Task<(bool success, string content)> RequestSessionResponse(string uuid, SLRPRequest request)
    {
        RpClient? client = await GetClientSession(uuid);
        
        if (string.IsNullOrEmpty(client.personality.character.name) || string.IsNullOrEmpty(client.personality.rules.name) || string.IsNullOrEmpty(client.personality.scenario.name))
        {
            return(false, "Incomplete personality");
        }
        
        if (!client.HasRpSession(uuid))
        {
            RpSession rpSession = new RpSession.Builder(uuid)
                .WithRules(client.personality.rules)
                .WithCharacter(client.personality.character)
                .WithScenario(client.personality.scenario)
                .WithMessage(new LLMMessage("user", request.message))
                .Build();

            client.rpSessions.Add(rpSession);
        }
        
        //Check / add RP session with target user uuid;
        
        //await llmService.LLMRequest()
        
        //RpClient? client = clientSessions.FirstOrDefault(client => client.uuid == request.uuid);
        return;
    }

    public async Task SetSessionPersonality(string uuid, LLMPersonality personality)
    {
        RpClient? client = await GetClientSession(uuid);
        client.personality = personality;
        
        return;
    }
}