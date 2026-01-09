using System.Diagnostics;
using DAL.Models;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BL.Middlewares;

public sealed class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _dbPath;
    private readonly string _source;

    public RequestLoggingMiddleware(RequestDelegate next, IConfiguration config, string source)
    {
        _next = next;

        var folder = Environment.SpecialFolder.LocalApplicationData;
        var connString =
            config.GetConnectionString("LogDatabase")
            ?? throw new Exception("LogDatabase connection missing.");

        _dbPath = Path.Combine(Environment.GetFolderPath(folder), connString);
        _source = source;
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
            Source = _source,
        };

        using var db = new LiteDatabase(new ConnectionString { Filename = _dbPath });
        db.GetCollection<LogEntry>("logs").Insert(entry);
    }
}
