using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using TakeawayFinder.Services;

namespace TakeawayFinder.Pages;

public partial class FindTakeaway : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Inject] private IGoogleMapsService GoogleMapsService { get; set; } = default!;
    [Inject] private ITakeawayFinderApiService TakeawayFinderApiService { get; set; } = default!;
    
    private PostcodeSearchModel SearchModel { get; set; } = new();
    private bool IsDeployedOnGitHubPages { get; set; }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (NavigationManager.BaseUri.Contains("github.io", StringComparison.OrdinalIgnoreCase))
            {
                IsDeployedOnGitHubPages = true;
                StateHasChanged();
            }
            else
            {
                await GoogleMapsService.InitMapAsync(51.53721, 0.04687, 10);
            }
        }
    }

    private async Task SearchRestaurantsAsync()
    {
        var postcode = SearchModel.Postcode!.Trim();
        
        var restaurants = await TakeawayFinderApiService.GetRestaurantsByPostcodeAsync(postcode);
        
        if (restaurants is { Count: > 0 })
        {
            await GoogleMapsService.AddMarkerAsync(restaurants);
        }
    }

    public class PostcodeSearchModel
    {
        [Required(ErrorMessage = "Please enter a postcode.")]
        [StringLength(8)]
        public string? Postcode { get; set; }
    }
}