using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using TakeawayFinder.Services;
using TakeawayFinder.Models;

namespace TakeawayFinder.Pages;

public partial class FindTakeaway : ComponentBase
{
    [Inject] private IGoogleMapsService GoogleMapsService { get; set; } = default!;
    [Inject] private HttpClient Client { get; set; } = default!;
    
    private PostcodeSearchModel SearchModel { get; set; } = new();
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await GoogleMapsService.InitMapAsync(51.53721, 0.04687, 10);
        }
    }
    
    private async Task SubmitPostcode()
    {
        try
        {
            var postcode = SearchModel.Postcode!.Trim();

            using HttpResponseMessage response =
                await Client.GetAsync($"https://takeaway-finder.onrender.com/{Uri.EscapeUriString(postcode)}");

            var responseBody = await response.Content.ReadAsStringAsync();

            var restaurants = JsonSerializer.Deserialize<List<RestaurantDto>>(responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (restaurants is { Count: > 0 })
            {
                await GoogleMapsService.AddMarkerAsync(restaurants);
            }
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Failed to reach the server.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Failed to parse the response.");
        }
    }

    public class PostcodeSearchModel
    {
        [Required(ErrorMessage = "Please enter a postcode.")]
        [StringLength(8)]
        public string? Postcode { get; set; }
    }
}