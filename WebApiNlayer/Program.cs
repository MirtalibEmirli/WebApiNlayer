using Application;
using AspNetCoreRateLimit;
using DAL.SqlServer;
using WebApiNlayer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddSqlServerServices(conn);

builder.Services.AddApplicationServices();
builder.Services.AddTransient<MainExceptionHandlerMiddleware>();


// 1️⃣ Memory Cache istifadə etmək üçün lazımlı xidmətləri əlavə edirik
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();

// 2️⃣ Rate Limiting konfiqurasiyasını yükləyirik
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

//
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseIpRateLimiting();

app.UseAuthorization();
app.UseMiddleware<MainExceptionHandlerMiddleware>();
//app.UseMiddleware<ExceptionHandlerMiddleware>();                
app.MapControllers();

app.Run();

//custom rate limit yaz --, yeni bir class add ed cqrs dto ile yaz ----, fso suallar birde+

