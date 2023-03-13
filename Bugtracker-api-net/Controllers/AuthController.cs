using Bugtracker_api_net.Contracts;
using Bugtracker_api_net.Repositories.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker_api_net.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/")]
public class AuthController : Controller
{
    private readonly ISender _mediatr;

    public AuthController(ISender mediatr)
    {
        _mediatr = mediatr;
    }
    
    [MapToApiVersion("1.0")]
    [Route("register/manager/email")]
    [HttpPost]
    public async Task<IActionResult> RegisterManagerWithEmail([FromBody]RegisterManagerContract request)
    {
        var response = await _mediatr.Send(new RegisterManagerCommand(){Contract = request});

        return Ok(response.Token);
    }   
}