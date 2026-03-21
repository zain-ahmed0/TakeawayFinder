using TakeawayFinder.Models;

namespace TakeawayFinder.Services;

public interface ITakeawayFinderApiService
{
    Task<List<RestaurantDto>?> GetRestaurantsByPostcodeAsync(
        string postcode
    );
}