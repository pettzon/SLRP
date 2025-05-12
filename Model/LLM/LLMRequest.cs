namespace SLRPBackend.Model.LLM;

[System.Serializable]
public class LLMRequest
{
    public string model = "nemomix-unleashed-12b";
    public List<LLMMessage> messages = new List<LLMMessage>();
    public double temperature = 0.8;
    public int max_tokens = -1;
    public bool stream = false;
}