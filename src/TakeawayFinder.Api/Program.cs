using TakeawayFinder.Api.Services;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5273")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddHttpClient<IJustEatApiService, JustEatApiService> (client =>
{
    client.BaseAddress = new Uri("https://uk.api-just.io/");
});

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.MapGet("/{postcode}", async (string postcode, IJustEatApiService justEatApiService) =>
{
    var result = await justEatApiService.GetRestaurantsByPostcodeAsync(postcode);
    
    return Results.Ok(result?.Restaurants);
}).RequireCors(myAllowSpecificOrigins);

app.Run();