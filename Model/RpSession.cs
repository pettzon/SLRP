using SLRPBackend.Model.LLM;

namespace SLRPBackend.Model;

public class RpSession
{
    public string clientId;
    public string userId;
    public string sessionId;

    public List<LLMMessage> messageHistory;

    public RpSession(string clientId, string userId, string sessionId)
    {
        this.clientId = clientId;
        this.userId = userId;
        this.sessionId = sessionId;
    }

    public class Builder
    {
        public RpSession rpSession;

        public Builder(string clientId, string userId, string sessionId)
        {
            rpSession = new RpSession(clientId, userId, sessionId);
        }

        public Builder WithPersonality()
        {
            return this;
        }

        public RpSession Build() => rpSession;
    }
}