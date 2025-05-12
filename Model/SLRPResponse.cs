using SLRPBackend.Data;

namespace SLRPBackend.Model;

public class SLRPResponse
{
    public string content { get; set; }
    public SLRPAction.Action action { get; set; }
    
    public SLRPResponse()
    {
        
    }
}