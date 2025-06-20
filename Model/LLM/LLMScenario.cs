namespace SLRPBackend.Model.LLM;

[System.Serializable]
public struct LLMScenario
{
    public string name { get; set; }
    public string scenario { get; set; }

    public LLMScenario(string name, string scenario)
    {
        this.name = name;
        this.scenario = scenario;
    }
}