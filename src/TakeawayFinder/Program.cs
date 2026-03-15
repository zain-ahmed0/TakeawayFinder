using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TakeawayFinder;
using TakeawayFinder.Interop;
using TakeawayFinder.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration["TakeawayFinderApiUrl"] ?? throw new InvalidOperationException("TakeawayFinderApiUrl is not configured in appsettings.");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
builder.Services.AddScoped<IGoogleMapsInterop, GoogleMapsInterop>();
builder.Services.AddScoped<IGoogleMapsService, GoogleMapsService>();

await builder.Build().RunAsync();