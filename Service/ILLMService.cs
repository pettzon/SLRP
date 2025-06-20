using SLRPBackend.Model.LLM;

namespace SLRPBackend.Service;

public interface ILLMService
{
    public Task<LLMResponse> LLMRequest(LLMRequest request);
}