using Microsoft.AspNetCore.HttpLogging;
using User_Management_API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GlobalExceptionMiddleware>();
builder.Services.AddTransient<InfoMiddleware>();
builder.Services.AddTransient<TokenValidationMiddleware>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<TokenValidationMiddleware>();
app.UseMiddleware<InfoMiddleware>();

app.MapControllers();

app.Run();
