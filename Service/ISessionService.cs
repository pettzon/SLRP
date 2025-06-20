using SLRPBackend.Model;
using SLRPBackend.Model.LLM;

namespace SLRPBackend.Service;

public interface ISessionService
{
    public void EndSession();
    public Task<RpClient> GetClientSession(string uuid);
    public Task<bool> ClientSessionExists(string uuid);
    public Task<(bool success, string content)> RequestSessionResponse(string uuid, SLRPRequest request);
    public Task SetSessionPersonality(string uuid, LLMPersonality personality);
}