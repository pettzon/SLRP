using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using SLRPBackend.Model.LLM;

namespace SLRPBackend.Service;

public sealed class LLMService : ILLMService
{
    private readonly string url;
    private readonly string api;
    
    public LLMService(string url = "http://127.0.0.1:1234", string api = "/v1/chat/completions")
    {
        this.url = url;
        this.api = api;
    }

    public async Task<LLMResponse> LLMRequest(LLMRequest request)
    {
        using(HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(url),
            DefaultRequestVersion = null,
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
            MaxResponseContentBufferSize = 0,
            Timeout = TimeSpan.FromSeconds(120)
        })
        {
            try
            {
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                
                string json = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                
                HttpResponseMessage result = await client.PostAsync(api, content);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    LLMResponse? llmResponse = JsonConvert.DeserializeObject<LLMResponse>(response);
                    
                    return llmResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return new LLMResponse();
    }
}