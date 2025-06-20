namespace SLRPBackend.Model.LLM;

[System.Serializable]
public struct LLMRules
{
    public string name { get; set; }
    public string rules { get; set; }

    public LLMRules(string name, string rules)
    {
        this.name = name;
        this.rules = rules;
    }
}