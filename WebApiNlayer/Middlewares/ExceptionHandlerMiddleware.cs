using Common.Exceptions;
using Common.GlobalResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Text.Json;

namespace WebApiNlayer.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next=next;
    }

    //InvokeAsync
    public async Task Invoke(HttpContext context  )
    {
        var message =new List<string>();
        var statusCode = HttpStatusCode.OK;
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            switch (error)
            {
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest; break;

                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound; break;    
                case DeleteFailedException:
                    statusCode = HttpStatusCode.BadRequest; break;
                case UpdateFailedException:
                    statusCode= HttpStatusCode.BadRequest; break;   


                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = new List<string>() { "InternalServerError maybe occured in the serverSide" };
                    break;
            }


        }
        await WriteError(context, statusCode, message);
    }

    private async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> message)
    {

        context.Response.Clear();   
        context.Response.ContentType = "application/json";  
        context.Response.StatusCode= (int)statusCode;  
        var json =JsonSerializer.Serialize(new ResponseModel(message));
        await context.Response.WriteAsync(json);
    }
}
