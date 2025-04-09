namespace SLRPBackend.Service;

public interface ISessionService
{
    public void CreateSession();
    public void EndSession();
    public void GetSession();
}