using Microsoft.OpenApi;
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
    client.BaseAddress = new Uri("https://uk.api.just-eat.io/");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TakeawayFinder API",
        Version = "v1",
        Description = "An API for finding takeaway restaurants by UK postcode via Just Eat Takeaway",
        Contact = new OpenApiContact
        {
            Name = "Zain Ahmed",
            Url = new Uri("https://github.com/zain-ahmed0/TakeawayFinder/"),
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(myAllowSpecificOrigins);

app.MapGet("/{postcode}", async (string postcode, IJustEatApiService justEatApiService) =>
{
    var result = await justEatApiService.GetRestaurantsByPostcodeAsync(postcode);
    
    return Results.Ok(result?.Restaurants);
}).RequireCors(myAllowSpecificOrigins);

app.Run();