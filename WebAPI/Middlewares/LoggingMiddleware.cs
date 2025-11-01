using System.Diagnostics;
using DAL.Models;
using LiteDB;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _dbPath;

    public LoggingMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;

        var connectionString =
            config.GetConnectionString("LogDatabase")
            ?? throw new Exception("DbString not found in appsettings.");

        _dbPath = Environment.ExpandEnvironmentVariables(connectionString);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        await _next(context);
        sw.Stop();

        var entry = new LogEntry
        {
            Method = context.Request.Method,
            Path = context.Request.Path,
            StatusCode = context.Response.StatusCode,
            DurationMs = sw.Elapsed.TotalMilliseconds,
        };

        using var db = new LiteDatabase(_dbPath);
        var col = db.GetCollection<LogEntry>("logs");
        col.Insert(entry);
    }
}
