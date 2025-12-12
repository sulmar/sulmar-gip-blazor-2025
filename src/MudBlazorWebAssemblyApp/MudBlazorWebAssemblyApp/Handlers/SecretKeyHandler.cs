
namespace MudBlazorWebAssemblyApp.Client.Handlers;

public class SecretKeyHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.TryAddWithoutValidation("x-secret-key", "123abc");

        return await base.SendAsync(request, cancellationToken);
    }
}

public class LoggerHandler(ILogger<LoggerHandler> logger) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("{Method} {RequestUri}", request.Method, request.RequestUri);

        return base.SendAsync(request, cancellationToken);
    }
}
