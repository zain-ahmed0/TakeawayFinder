using System.Text.Json;
using TakeawayFinder.Models;

namespace TakeawayFinder.Api.Services;

public class JustEatApiService : IJustEatApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<JustEatApiService> _logger;

    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public JustEatApiService(HttpClient httpClient, ILogger<JustEatApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<JustEatResponseDto?> GetRestaurantsByPostcodeAsync(string postcode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(postcode);

        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"restaurants/bypostcode/{postcode}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<JustEatResponseDto>(content, _options);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to fetch restaurants for postcode {Postcode}", postcode);
            throw;
        }
    }
}