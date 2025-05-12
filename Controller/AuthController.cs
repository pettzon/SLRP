using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SLRPBackend.Service;

namespace SLRPBackend.Controller;

[ApiController]
[Route("api/session/auth/{uuid}")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService authService;
    
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AuthAsync(string uuid, CancellationToken cancellationToken = default)
    {
        bool success = await authService.Authorize(uuid);
        //Debug.WriteLine($"Tried to auth {uuid} Success : {success}");
        
        return Ok();
    }
}