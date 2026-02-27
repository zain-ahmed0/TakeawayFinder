using TakeawayFinder.Interop;
using TakeawayFinder.Models;

namespace TakeawayFinder.Services;

public class GoogleMapsService : IGoogleMapsService
{
    private readonly IGoogleMapsInterop _interop;
    
    public GoogleMapsService(IGoogleMapsInterop interop)
    {
        _interop = interop;
    }

    public async Task InitMapAsync(double latitude, double longitude, int zoom)
    {
        await _interop.InitMapAsync(latitude, longitude, zoom);
    }

    public async Task AddMarkerAsync(IEnumerable<RestaurantDto> restaurants)
    {
        await _interop.AddMarkerAsync(restaurants);
    }
}