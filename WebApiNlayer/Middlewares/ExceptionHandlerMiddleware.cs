using Common.Exceptions;
using Common.GlobalResponses;
using System.Net;
using System.Text.Json;

namespace WebApiNlayer.Middlewares;

public class ExceptionHandlerMiddleware  
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
 
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception error)
        {

            switch (error)
            {
                
                case BadRequestException :
                    var message = new List<string>() { "error.Message" };
                    await WriteError(httpContext, HttpStatusCode.BadRequest,message);
                    break;

                    case NotFoundException :    
                      message = new List<string>() { "error.Message" };
                    await WriteError(httpContext, HttpStatusCode.NotFound, message);
                    break;
            }
        }
    }

    private static async Task WriteError(HttpContext httpContext, HttpStatusCode requestStatus, List<string> message)
    {
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = (int)requestStatus;

        httpContext.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(new ResponseModel(message)); 
        await httpContext.Response.WriteAsync(json);
    }

   
} 
  

 