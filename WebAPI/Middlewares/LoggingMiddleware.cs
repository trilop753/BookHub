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

        var folder = Environment.SpecialFolder.LocalApplicationData;
        var connectionString =
            config.GetConnectionString("LogDatabase")
            ?? throw new Exception("LogDatabase name not found in appsettings.");
        var path = Path.Combine(Environment.GetFolderPath(folder), connectionString);
        _dbPath = path;
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
            Source = "API"
        };

        using var db = new LiteDatabase(new ConnectionString
        {
            Filename = _dbPath
        });

        var col = db.GetCollection<LogEntry>("logs");
        col.Insert(entry);
    }
}