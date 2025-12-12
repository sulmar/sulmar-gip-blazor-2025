namespace Api.Middlewares;

public class AuthMiddleware(RequestDelegate next)
{
    public string SecretKey { get; set; }

    public async Task InvokeAsync(HttpContext context)
    {        
        if (context.Request.Path.StartsWithSegments("/signalr"))
        {
            await next(context);

            return;
        }

        if (!context.Request.Headers.TryGetValue("x-secret-key", out var secretkey) || secretkey != "123abc")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await next(context);
    }

}

