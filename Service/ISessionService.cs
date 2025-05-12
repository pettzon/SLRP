using SLRPBackend.Model;

namespace SLRPBackend.Service;

public interface ISessionService
{
    public void EndSession();
    public Task<RpClient> GetSession(string uuid);
    public Task<bool> SessionExists(string uuid);
    public Task PostSession(SLRPRequest request);
}