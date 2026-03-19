using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.Use(
    async (context, next) =>
    {
        Console.WriteLine($"Method: {context.Request.Method} - Path: ${context.Request.Path}");
        await next.Invoke();
        Console.WriteLine($"Respone code: {context.Response.StatusCode}");
    }
);

app.MapControllers();

app.Run();
