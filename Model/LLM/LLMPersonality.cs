namespace SLRPBackend.Model.LLM;

[System.Serializable]
public struct LLMPersonality
{
    public LLMRules rules { get; set; }
    public LLMCharacter character { get; set; }
    public LLMScenario scenario { get; set; }

    public LLMPersonality(LLMRules rules, LLMCharacter character, LLMScenario scenario)
    {
        this.rules = rules;
        this.character = character;
        this.scenario = scenario;
    }
}