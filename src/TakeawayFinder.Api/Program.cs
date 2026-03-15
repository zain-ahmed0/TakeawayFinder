using Scalar.AspNetCore;
using TakeawayFinder.Api.Services;
using TakeawayFinder.Models;

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

builder.Services.AddHttpClient<IJustEatApiService, JustEatApiService>(client =>
    {
        client.BaseAddress = new Uri("https://uk.api.just-eat.io/");
    })
    .AddStandardResilienceHandler();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Takeaway Finder API",
            Version = "v1",
            Description =
                "API for discovering takeaway restaurants by UK postcode, powered by the Just Eat Takeaway API.",
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.MapGet("/restaurants/bypostcode/{postcode}", async (string postcode, IJustEatApiService justEatApiService) =>
{
    if (postcode.Length > 8 || !postcode.All(c  => char.IsLetterOrDigit(c) || c == ' '))
    {
        return Results.BadRequest();
    }
    
    var result = await justEatApiService.GetRestaurantsByPostcodeAsync(postcode);
    
    return Results.Ok(result?.Restaurants);
})
    .WithName("GetRestaurantsByPostcode")
    .WithSummary("Get Restaurants by postcode")
    .WithDescription("Returns a list of takeaway restaurants for a given UK postcode.")
    .WithTags("Restaurants")
    .Produces<IEnumerable<RestaurantDto>>(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status400BadRequest)
    .RequireCors(myAllowSpecificOrigins);

app.MapOpenApi();
app.MapScalarApiReference("/docs");

app.Run();