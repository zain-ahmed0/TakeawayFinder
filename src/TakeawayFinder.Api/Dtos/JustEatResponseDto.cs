using System.Text.Json.Serialization;

namespace TakeawayFinder.Api.Dtos;

public class JustEatResponseDto
{
    [JsonPropertyName("restaurants")]
    public List<RestaurantDto> Restaurants { get; set; }
}