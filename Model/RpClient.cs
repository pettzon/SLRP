using SLRPBackend.Model.LLM;

namespace SLRPBackend.Model;

public class RpClient
{
    public string uuid { get; private set; }
    public HashSet<RpSession> rpSessions = new HashSet<RpSession>();
    public LLMPersonality personality;
    
    public RpClient(string uuid)
    {
        this.uuid = uuid;
    }

    public void AddRpSessionMessage(SLRPRequest request)
    {
        
    }
    
    public bool HasRpSession(string uuid)
    {
        foreach (RpSession session in rpSessions)
        {
            if (session.clientId != uuid) continue;
            return true;
        }

        return false;
    }
}