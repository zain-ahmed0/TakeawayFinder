using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class Address
{
    [Description("The restaurant's address")]
    [JsonPropertyName("firstLine")]
    public string? FirstLine { get; set; }
    
    [Description("The restaurant's latitude")]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    
    [Description("The restaurant's longitude")]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}