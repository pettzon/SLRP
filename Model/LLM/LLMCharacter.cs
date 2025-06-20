namespace SLRPBackend.Model.LLM;

[System.Serializable]
public struct LLMCharacter
{
    public string name { get; set; }
    public string character { get; set; }

    public LLMCharacter(string name, string character)
    {
        this.name = name;
        this.character = character;
    }
}