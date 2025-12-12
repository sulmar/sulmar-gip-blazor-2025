using System.Data.SqlTypes;

namespace Api.Middlewares;

// Wzorzec Projektowy lancuch odpowiedzialnosci

public static class LoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseLogger(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggerMiddleware>();
    }
}

public static class AuthMiddlewareExtensions
{
    public static IApplicationBuilder UseSecretKey(this IApplicationBuilder app, string secretKey)
    {
         return app.UseMiddleware<AuthMiddleware>();
        
    }
}

public class LoggerMiddleware
{
    private readonly RequestDelegate next;

    public LoggerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"{context.Request.Method} {context.Request.Path}");

        await next(context);

        Console.WriteLine($"{context.Response.StatusCode}");
    }
}


public class AuthMiddleware(RequestDelegate next)
{
    public string SecretKey { get; set; }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("x-secret-key", out var secretkey) || secretkey != "123abc")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await next(context);
    }

}

