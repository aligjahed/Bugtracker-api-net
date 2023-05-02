using Bugtracker_api_net.Middleware.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Bugtracker_api_net.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/")]
public class ErrorController : Controller
{
    [Route("error")]
    [MapToApiVersion("1.0")]
    public IActionResult Index()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
        var code = 500;

        if (exception is CostumeException e)
        {
            code = (int)e.StatusCode;
        }
        
        return Problem(statusCode: code , title: exception.Message);
    }
}