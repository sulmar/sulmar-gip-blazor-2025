using Microsoft.JSInterop;

namespace MudBlazorWebAssemblyApp.Client.Services;

// Abstract Adapter
public interface ILocalStorageService
{
    Task SetItem(string key, string value);
    Task<string> GetItem(string key);
}

// Concrete Adapter
public class LocalStorageService(IJSRuntime JS) : ILocalStorageService
{
    public async Task<string> GetItem(string key)
    {
        return await JS.InvokeAsync<string>("localStorage.getItem", key);
    }

    public async Task SetItem(string key, string value)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", key, value);
    }
}
