# Architecture

## Project Tree

```
TakeawayFinder/
│
└── src/
    ├── TakeawayFinder/                     # Blazor WebAssembly Frontend
    │   ├── Program.cs                      # Entry point: configures DI, HttpClient, services
    │   ├── Pages/
    │   │   ├── Home.razor                  # Landing page
    │   │   └── FindTakeaway.razor(.cs)     # Main feature: postcode search + map display
    │   ├── Services/
    │   │   └── TakeawayFinderApiService.cs # HTTP client to backend API
    │   ├── Interop/
    │   │   └── GoogleMapsInterop.cs        # JS interop bridge to Google Maps
    │   └── wwwroot/
    │       └── js/
    │           └── googleMapsInterop.js    # Google Maps: markers and clustering
    │
    ├── TakeawayFinder.Api/                 # ASP.NET Core Minimal API Backend
    │   ├── Program.cs                      # Entry point: CORS, endpoint, validation
    │   ├── Services/
    │       └── JustEatApiService.cs        # Proxies requests to the Just Eat Takeaway API
    │
    └── TakeawayFinder.Models/              # Shared DTO Library 

```
