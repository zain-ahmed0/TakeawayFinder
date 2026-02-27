using System.Text.Json;
using Microsoft.AspNetCore.Components;
using TakeawayFinder.Services;
using TakeawayFinder.Models;

namespace TakeawayFinder.Pages;

public partial class FindTakeaway : ComponentBase
{
    [Inject] private IGoogleMapsService GoogleMapsService { get; set; }
    [Inject] private HttpClient client { get; set; }
    
    public static string? submittedPostcode = string.Empty;
    private static string? postcode = string.Empty;
    
    private void SubmitPostcode()
    {
        postcode = submittedPostcode;

        GetData();

        SerializeData();

        submittedPostcode = string.Empty;
    }
    
    private async Task<String> GetData()
    {
        using HttpResponseMessage response = await client.GetAsync($"https://takeaway-finder.onrender.com/{postcode}");
        
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await GoogleMapsService.InitMapAsync(51.53721, 0.04687, 10);
        }
    }
    
    private async Task SerializeData()
    {
        string data = await GetData();
            
        var result = JsonSerializer.Deserialize<List<RestaurantDto>>(
            data,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
        // foreach (var restaurant in result)
        // {
        //     await GoogleMapsService.AddMarkerAsync(restaurant.Address.Latitude, restaurant.Address.Longitude, restaurant.Name, restaurant.Url);
        // }

        await GoogleMapsService.AddMarkerAsync(result);
    }
}