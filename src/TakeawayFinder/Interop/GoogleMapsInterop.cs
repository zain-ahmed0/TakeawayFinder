using Microsoft.JSInterop;
using TakeawayFinder.Models;

namespace TakeawayFinder.Interop;

public class GoogleMapsInterop : IGoogleMapsInterop, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;

    public GoogleMapsInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    private async Task EnsureModuleAsync()
    {
        _module ??= await _jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./js/googleMapsInterop.js");

        if (_module is null)
        {
            throw new InvalidOperationException("Google Maps Interop is not initialized.");
        }
    }

    public async Task InitMapAsync(double latitude, double longitude, int zoom)
    {
        await EnsureModuleAsync();
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("initMapAsync", latitude, longitude, zoom);
        }
    }

    public async Task AddMarkerAsync(IEnumerable<RestaurantDto> restaurants)
    {
        await EnsureModuleAsync();
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("addMarkerAsync", restaurants);
        }
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}