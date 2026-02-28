using TakeawayFinder.Models;

namespace TakeawayFinder.Api.Services;

public interface IJustEatApiService
{
    Task<JustEatResponseDto?> GetRestaurantsByPostcodeAsync(string postcode);
}