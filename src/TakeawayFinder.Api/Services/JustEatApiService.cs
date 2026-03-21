using Polly.CircuitBreaker;
using Polly.Timeout;
using System.Text.Json;
using TakeawayFinder.Models;

namespace TakeawayFinder.Api.Services;

public partial class JustEatApiService : IJustEatApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<JustEatApiService> _logger;
    
    public JustEatApiService(HttpClient httpClient, ILogger<JustEatApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<JustEatResponseDto?> GetRestaurantsByPostcodeAsync(string postcode)
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"restaurants/bypostcode/{postcode}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<JustEatResponseDto>(content, JsonSerializerOptions.Web);
        }
        catch (HttpRequestException ex)
        {
            Log.LogFetchRestaurantsFailed(_logger, postcode, ex);
            throw;
        }
        catch (TimeoutRejectedException ex)
        {
            Log.LogFetchRestaurantsFailed(_logger, postcode, ex);
            throw;
        }
        catch (BrokenCircuitException ex)
        {
            Log.LogFetchRestaurantsFailed(_logger, postcode, ex);
            throw;
        }
    }
    
    private static partial class Log
    {
        [LoggerMessage(1, LogLevel.Error, "Failed to fetch restaurants for postcode {Postcode}")]
        public static partial void LogFetchRestaurantsFailed(ILogger logger, string postcode, Exception exception);
    }
}