using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class Address
{
    [JsonPropertyName("firstLine")]
    public string FirstLine { get; set; }
    
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}