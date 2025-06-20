namespace SLRPBackend.Model.LLM;

public class LLMChoices
{
    public int index;
    public string logprobs = "";
    public string finish_reason = "";
    public List<LLMMessage> message = new List<LLMMessage>();
}