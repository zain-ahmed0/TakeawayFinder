using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class RestaurantDto
{
    [Description("The name of the restaurant")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [Description("The unique name of the restaurant")]
    [JsonPropertyName("uniqueName")]
    public string? UniqueName { get; set; }

    [Description("The restaurant's address")]
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
    
    [Description("The restaurant's page on Just Eat Takeaway")]
    [JsonPropertyName("url")]
    public string? Url => $"https://www.just-eat.co.uk/restaurants-{UniqueName}/menu";

    [Description("URL to the restaurant's logo")]
    [JsonPropertyName("logourl")]
    public string? LogoUrl { get; set; }
}