using Microsoft.AspNetCore.HttpLogging;
using User_Management_API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GlobalExceptionMiddleware>();
builder.Services.AddTransient<InfoMiddleware>();
builder.Services.AddTransient<TokenValidationMiddleware>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<TokenValidationMiddleware>();
app.UseMiddleware<InfoMiddleware>();

app.MapControllers();

app.Run();
