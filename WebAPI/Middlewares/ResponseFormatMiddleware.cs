using System.Text;
using Newtonsoft.Json;

public sealed class ResponseFormatMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseFormatMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        await using var buffer = new MemoryStream();
        context.Response.Body = buffer;

        try
        {
            await _next(context);

            buffer.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(buffer, Encoding.UTF8).ReadToEndAsync();

            var target = DecideTargetFormat(context);

            string output = bodyText;
            string contentType = "application/json; charset=utf-8";

            if (target == "xml" && !string.IsNullOrWhiteSpace(bodyText))
            {
                output = ConvertJsonToXml(bodyText.Trim());
                contentType = "application/xml; charset=utf-8";
            }

            context.Response.ContentType = contentType;
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(output);

            context.Response.Body = originalBody;
            await originalBody.WriteAsync(Encoding.UTF8.GetBytes(output));
        }
        finally
        {
            context.Response.Body = originalBody;
        }
    }

    private static string DecideTargetFormat(HttpContext ctx)
    {
        if (ctx.Request.Query.TryGetValue("format", out var q))
        {
            var v = q.ToString().Trim().ToLowerInvariant();
            if (v == "xml" || v == "json")
            {
                return v;
            }
        }

        if (ctx.Request.Headers.TryGetValue("Accept", out var accept))
        {
            var a = accept.ToString().ToLowerInvariant();
            if (a.Contains("xml"))
            {
                return "xml";
            }

            if (a.Contains("json"))
            {
                return "json";
            }
        }

        return "json";
    }

    private static string ConvertJsonToXml(string json)
    {
        try
        {
            if (json.TrimStart().StartsWith("["))
            {
                json = $"{{\"items\":{{\"item\":{json}}}}}";
                var docArr = JsonConvert.DeserializeXmlNode(json, "root");
                if (docArr != null)
                {
                    return docArr.OuterXml;
                }

                return json;
            }

            var doc = JsonConvert.DeserializeXmlNode(json, "root");
            if (doc != null)
            {
                return doc.OuterXml;
            }

            return json;
        }
        catch
        {
            return json;
        }
    }
}
