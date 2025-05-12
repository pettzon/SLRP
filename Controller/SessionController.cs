using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SLRPBackend.Model;
using SLRPBackend.Service;

namespace SLRPBackend.Controller;

[ApiController]
[Route("api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService sessionService;
    private readonly IAuthService authService;
    
    public SessionController(IAuthService authService, ISessionService sessionService)
    {
        this.authService = authService;
        this.sessionService = sessionService;
    }

    [HttpPost]
    public async Task<IActionResult> SessionPostAsync(SLRPRequest request, CancellationToken cancellationToken = default)
    {
        if (!await sessionService.SessionExists(request.uuid))
        {
            return BadRequest();
        }
        
        //await sessionService.PostSession(request);
        
        return Ok();
    }
}