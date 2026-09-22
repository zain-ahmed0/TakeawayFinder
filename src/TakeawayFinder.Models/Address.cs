using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class Address
{
    [Description("The restaurant's address")]
    [JsonPropertyName("firstLine")]
    public string? FirstLine { get; set; }
    
    [Description("The restaurant's latitude and longitude")]
    [JsonPropertyName("location")]
    public GeoLocation? Location { get; set; }
}