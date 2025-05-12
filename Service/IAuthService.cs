namespace SLRPBackend.Service;

public interface IAuthService
{
    public event Action<string> OnAuthorize;
    public Task<bool> Authorize(string token);
}