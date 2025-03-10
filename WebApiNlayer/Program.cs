﻿using Application;
using AspNetCoreRateLimit;
using DAL.SqlServer;
using Microsoft.OpenApi.Models;
using WebApiNlayer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
   
});

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
//app.UseIpRateLimiting();

app.UseAuthorization();

app.UseMiddleware<MainExceptionHandlerMiddleware>();
//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();

//custom rate limit yaz --, yeni bir class add ed cqrs dto ile yaz ----, fso suallar birde+

