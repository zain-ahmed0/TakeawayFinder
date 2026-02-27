using TakeawayFinder.Models;

namespace TakeawayFinder.Interop;

public interface IGoogleMapsInterop
{
    Task InitMapAsync(
        double latitude,
        double longitude,
        int zoom);

    Task AddMarkerAsync(
        IEnumerable<RestaurantDto> restaurants
    );
}