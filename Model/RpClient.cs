namespace SLRPBackend.Model;

public class RpClient
{
    public string uuid { get; private set; }
    public HashSet<RpSession> rpSessions = new HashSet<RpSession>();
    
    public RpClient(string uuid)
    {
        this.uuid = uuid;
    }
}