namespace SLRPBackend.Model.LLM;

public class LLMResponse
{
    public string id = "";
    public int created;
    public string model = "";
    public LLMChoices choices = new LLMChoices();
    public LLMUsage usage = new LLMUsage();
    public string system_fingerprint = "";
}