using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace User_Management_API.Middlewares
{
    public class InfoMiddleware : IMiddleware
    {
        private ILogger<InfoMiddleware> _logger;

        public InfoMiddleware(ILogger<InfoMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation(
                $"Method: {context.Request.Method} - Path: ${context.Request.Path}"
            );
            await next(context);
            _logger.LogInformation($"Response code: {context.Response.StatusCode}");
        }
    }
}
