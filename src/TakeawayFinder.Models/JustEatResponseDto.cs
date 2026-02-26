using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class JustEatResponseDto
{
    [JsonPropertyName("restaurants")]
    public List<RestaurantDto> Restaurants { get; set; }
}