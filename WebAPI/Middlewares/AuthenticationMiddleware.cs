namespace WebAPI.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AccessToken = "secrettoken123";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Missing access token.");
                return;
            }

            var tokenValue = token.ToString().Trim();

            if (tokenValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                tokenValue = tokenValue.Substring("Bearer ".Length).Trim();
            }

            if (tokenValue != AccessToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid access token.");
                return;
            }

            await _next(context);
        }
    }
}
