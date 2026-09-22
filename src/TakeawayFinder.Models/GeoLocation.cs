using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TakeawayFinder.Models;

public class GeoLocation
{
    [Description("The restaurant's geo location")]
    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; }
}