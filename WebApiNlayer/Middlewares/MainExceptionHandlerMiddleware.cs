
using Common.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Text.Json;

namespace WebApiNlayer.Middlewares;

public class MainExceptionHandlerMiddleware : IMiddleware
{

    //bu methodu yaz Program.cs de elave ed, bunu o birine baxib yaz , sora onuda sil tezeden yaz
    //iksindede eyni excewptionlari tuta bilersen
    //status code bax onlari oyren 
    //Customer classi ucun olan cruudlari bitir ilk o nce
    //burdada dapperi oxu crud uzre bitir https://www.learndapper.com/
    //cqrs pattern haqqinda oxu arasdir https://www.gencayyildiz.com/blog/cqrs-pattern-nedir-mediatr-kutuphanesi-ile-nasil-uygulanir/  ++
    //ve bulari yazarken exceptionlar elave ed
    //bundan elave ucuncu bir class yarat ve ona sifirdan butun bunlari tetbiq ed
    //rate nese middleware var onu da edmelyik requestler ucun


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            switch (error)
            {
                case BadRequestException:
                    var message=new List<string>(){ error.Message};
                    await WriteError(context,HttpStatusCode.BadRequest, message);
                    break;
                case NotFoundException:
                    message = new List<string>() { error.Message};  
                    await WriteError(context,HttpStatusCode.BadRequest,message);
                    break;
                default:
                    break;
            }

        }

    }

    public async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> message)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var json = JsonSerializer.Serialize(message);
      await  context.Response.WriteAsync(json);
    }




}
