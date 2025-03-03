using Common.Exceptions;
using System.Collections.Concurrent;

namespace WebApiNlayer.Middlewares;

public class RateLimitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly int _requestLimit;
    private readonly TimeSpan _timeSpan;
    private readonly IHttpContextAccessor _contextAccessor;

    private readonly ConcurrentDictionary<string, List<DateTime>> _requestTimes = new();

    public RateLimitMiddleware(RequestDelegate next, int requestLimit, TimeSpan timeSpan, IHttpContextAccessor contextAccessor)
    {
        _next = next;
        _requestLimit = requestLimit;
        _timeSpan = timeSpan;
        _contextAccessor = contextAccessor;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        if (!isAuthenticated)
        {
            var clientId = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var now = DateTime.Now;
            var requestLog = _requestTimes.GetOrAdd(clientId, new List<DateTime>());
            lock (requestLog)
            {
                requestLog.RemoveAll(timeStamp => timeStamp <= now - _timeSpan);
                if (requestLog.Count >= _requestLimit)
                {
                    //context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    //context.Response.Headers.RetryAfter = _timeSpan.TotalMinutes.ToString();
                    throw new RateLimitException($"TooManyRequest .ErrorCode is {StatusCodes.Status429TooManyRequests}    Allowed Request is for {_timeSpan} 2");

                }
                requestLog.Add(now);
            }
            await _next(context);


        }
        await _next(context);
    }

}
