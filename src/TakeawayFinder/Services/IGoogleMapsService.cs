using TakeawayFinder.Models;

namespace TakeawayFinder.Services;

public interface IGoogleMapsService
{
    Task InitMapAsync(
        double latitude,
        double longitude,
        int zoom);

    Task AddMarkersAsync(
        IEnumerable<RestaurantDto> restaurants);
}