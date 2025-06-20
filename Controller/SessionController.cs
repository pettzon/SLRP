using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SLRPBackend.Model;
using SLRPBackend.Model.LLM;
using SLRPBackend.Service;

namespace SLRPBackend.Controller;

[ApiController]
[Route("api/session/{uuid}")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService sessionService;
    private readonly IAuthService authService;
    
    public SessionController(IAuthService authService, ISessionService sessionService)
    {
        this.authService = authService;
        this.sessionService = sessionService;
    }

    [HttpPost("RequestResponse")]
    public async Task<IActionResult> SessionPostAsync(string uuid, SLRPRequest request, CancellationToken cancellationToken = default)
    {
        if (!await sessionService.ClientSessionExists(uuid))
        {
            return BadRequest();
        }
        
        //await sessionService.PostSession(request);
        
        return Ok();
    }

    [HttpPost("Personality")]
    public async Task<IActionResult> SetPersonalityAsync(string uuid, LLMPersonality personality, CancellationToken cancellationToken = default)
    {
        if (!await sessionService.ClientSessionExists(uuid))
        {
            return BadRequest();
        }
        
        return Ok();
    }

    [HttpGet("KeepAlive")]
    public async Task<IActionResult> KeepAliveAsync(string uuid, CancellationToken cancellationToken = default)
    {
        if (!await sessionService.ClientSessionExists(uuid))
        {
            return BadRequest();
        }
        
        return Ok();
    }
}