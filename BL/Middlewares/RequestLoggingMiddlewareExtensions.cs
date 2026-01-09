using Microsoft.AspNetCore.Builder;

namespace BL.Middlewares;

public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app, string source)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>(source);
    }
}
