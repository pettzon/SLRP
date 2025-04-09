namespace SLRPBackend.Model;

[System.Serializable]
public class SLRPBackendRequest
{
    public string token;
    public string clientId;
    public string userId;
    public string sessionId;
    public string content;
}