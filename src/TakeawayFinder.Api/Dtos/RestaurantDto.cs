using System.Text.Json.Serialization;

namespace TakeawayFinder.Api.Dtos;

public class RestaurantDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("address")]
    public Address Address { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("logourl")]
    public string LogoUrl { get; set; }
}