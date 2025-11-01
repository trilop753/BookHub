using System.Diagnostics;
using DAL.Data;
using DAL.Models;

namespace WebAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public LoggingMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();

            using var scope = _scopeFactory.CreateScope();
            var logDb = scope.ServiceProvider.GetRequiredService<LogDbContext>();

            var entry = new LogEntry
            {
                Method = context.Request.Method,
                Path = context.Request.Path,
                StatusCode = context.Response.StatusCode,
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Timestamp = DateTime.UtcNow,
            };

            logDb.Logs.Add(entry);
            await logDb.SaveChangesAsync();
        }
    }
}
