using SLRPBackend.Model.LLM;

namespace SLRPBackend.Model;

public class RpSession
{
    public string clientId;

    public List<LLMMessage> messageHistory;

    public RpSession(string clientId)
    {
        this.clientId = clientId;
    }

    public class Builder
    {
        public RpSession rpSession;

        public Builder(string clientId, string userId, string sessionId)
        {
            rpSession = new RpSession(clientId);
        }

        public Builder WithPersonality()
        {
            return this;
        }

        public RpSession Build() => rpSession;
    }
}