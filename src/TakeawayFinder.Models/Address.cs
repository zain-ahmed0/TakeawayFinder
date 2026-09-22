using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class Address
{
    [Description("The restaurant's address")]
    [JsonPropertyName("firstLine")]
    public string? FirstLine { get; set; }
}