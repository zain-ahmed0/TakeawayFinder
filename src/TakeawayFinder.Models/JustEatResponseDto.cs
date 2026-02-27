using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class JustEatResponseDto
{
    [JsonPropertyName("restaurants")]
    public IEnumerable<RestaurantDto> Restaurants { get; set; }
}