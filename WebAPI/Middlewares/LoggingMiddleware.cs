using System.Diagnostics;

namespace WebAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation(
                $"Incoming request: {context.Request.Method} {context.Request.Path}"
            );

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation(
                $"Request handled: {context.Request.Method} {context.Request.Path} in {stopwatch.ElapsedMilliseconds} ms"
            );
        }
    }
}
