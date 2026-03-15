using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class JustEatResponseDto
{
    [Description("List of restaurants")]
    [JsonPropertyName("restaurants")]
    public IEnumerable<RestaurantDto>? Restaurants { get; set; }
}