using System.Net.Http.Json;
using TakeawayFinder.Models;

namespace TakeawayFinder.Services;

public partial class TakeawayFinderApiService : ITakeawayFinderApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TakeawayFinderApiService> _logger;

    public TakeawayFinderApiService(HttpClient httpClient, ILogger<TakeawayFinderApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<RestaurantDto>?> GetRestaurantsByPostcodeAsync(string postcode)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<RestaurantDto>>(
                $"restaurants/bypostcode/{Uri.EscapeDataString(postcode)}");
        }
        catch (HttpRequestException ex)
        {
            Log.LogFetchRestaurantsFailed(_logger, postcode, ex);
            return null;
        }
    }

    private static partial class Log
    {
        [LoggerMessage(1, LogLevel.Error, "Failed to fetch restaurants for postcode {Postcode}")]
        public static partial void LogFetchRestaurantsFailed(ILogger logger, string postcode, Exception exception);
    }
}