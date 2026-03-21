using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class RestaurantDto
{
    [Description("The name of the restaurant")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Description("The restaurant's address")]
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [Description("The restaurant's page on Just Eat Takeaway")]
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [Description("URL to the restaurant's logo")]
    [JsonPropertyName("logourl")]
    public string? LogoUrl { get; set; }
}