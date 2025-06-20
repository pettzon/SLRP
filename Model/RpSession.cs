using SLRPBackend.Model.LLM;

namespace SLRPBackend.Model;

public class RpSession
{
    public string clientId;

    public List<LLMMessage> messageHistory = new List<LLMMessage>();

    public RpSession(string clientId)
    {
        this.clientId = clientId;
    }

    public class Builder
    {
        public RpSession rpSession;

        public Builder(string clientId)
        {
            rpSession = new RpSession(clientId);
        }

        public Builder WithRules(LLMRules rules)
        {
            rpSession.messageHistory.Add(new LLMMessage("user", rules.rules));
            return this;
        }

        public Builder WithCharacter(LLMCharacter character)
        {
            rpSession.messageHistory.Add(new LLMMessage("user", character.character));
            return this;
        }

        public Builder WithScenario(LLMScenario scenario)
        {
            rpSession.messageHistory.Add(new LLMMessage("user", scenario.scenario));
            return this;
        }

        public Builder WithMessage(LLMMessage message)
        {
            rpSession.messageHistory.Add(message);
            return this;
        }

        public RpSession Build() => rpSession;
    }
}