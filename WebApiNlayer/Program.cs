using Application;
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

//
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<MainExceptionHandlerMiddleware>();
app.MapControllers();                                                                                           

app.Run();
