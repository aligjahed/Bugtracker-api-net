using Bugtracker_api_net.Middleware.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Bugtracker_api_net.Controllers;

public class ErrorController : Controller
{
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