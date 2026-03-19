using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace User_Management_API.Middlewares;

public class TokenValidationMiddleware : IMiddleware
{
    private readonly ILogger<TokenValidationMiddleware> _logger;
    private const string SecretToken = "123456789"; // Example key token for testing

    public TokenValidationMiddleware(ILogger<TokenValidationMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            _logger.LogWarning("Authorization heading is missing");
            await ReturnUnauthorized(context, "Missing token.");
            return;
        }

        var token = authHeader.ToString().Replace("Bearer ", "");

        if (token != SecretToken)
        {
            _logger.LogWarning($"Bad token: {token}");
            await ReturnUnauthorized(context, "Invalid or expired token.");
            return;
        }

        _logger.LogInformation("Token verified successfully");
        await next(context);
    }

    private static async Task ReturnUnauthorized(HttpContext context, string message)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new { error = "Unauthorized", details = message });
    }
}
