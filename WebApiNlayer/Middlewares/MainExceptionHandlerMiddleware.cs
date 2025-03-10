
using Common.Exceptions;
using Common.GlobalResponses;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace WebApiNlayer.Middlewares;

public class MainExceptionHandlerMiddleware : IMiddleware
{

    //bu methodu yaz Program.cs de elave ed, bunu o birine baxib yaz , sora onuda sil tezeden yaz+
    //iksindede eyni excewptionlari tuta bilersen++
    //status code bax onlari oyren +
    //Customer classi ucun olan cruudlari bitir ilk o nce-
    //burdada dapperi oxu crud uzre bitir https://www.learndapper.com/
    //ve bulari yazarken exceptionlar elave ed+
    //bundan elave ucuncu bir class yarat ve ona sifirdan butun bunlari tetbiq ed-
    //rate nese middleware var onu da edmelyik requestler ucun++


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            var message = new List<string>() { error.Message };
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            switch (error)
            {

                case BadRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;

                case DeleteFailedException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case UpdateFailedException:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
                case ValidationException ex:
                    await WriteValidationError(context, HttpStatusCode.BadRequest, ex);
                    return;

                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;    

                    break;
            }
            await WriteError(context, httpStatusCode, message);

        }

    }

    public async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> message)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var json = JsonSerializer.Serialize(new ResponseModel(message));
        await context.Response.WriteAsync(json);
    }

    public async Task WriteValidationError(HttpContext context,HttpStatusCode statusCode, ValidationException exception)
    {
        context.Response.Clear();
        context.Response.StatusCode= (int)statusCode;   
        context.Response.ContentType= "application/json";

        var validationErrors = exception.Errors.Select(e => new { field = e.PropertyName,message=e.ErrorMessage });

        var  json = JsonSerializer.Serialize(new {validationErrors = validationErrors});                        
        await context.Response.WriteAsync(json);
    }


}
