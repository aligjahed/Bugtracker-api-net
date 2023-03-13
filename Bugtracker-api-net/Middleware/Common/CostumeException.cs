using System.Net;

namespace Bugtracker_api_net.Middleware.Common;

public class CostumeException : Exception
{
    public HttpStatusCode StatusCode { get; set; } 

    public CostumeException(HttpStatusCode statusCode , string message = "There was an internal server error") : base(message: message)
    {
        StatusCode = statusCode;
    }
}