using System.Text.Json;
using TakeawayFinder.Api;
using TakeawayFinder.Api.Dtos;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5273")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/{postcode}", async (string postcode) =>
{
    string data = await JustEatApiService.GetData(postcode);
    
    var result = JsonSerializer.Deserialize<JustEatResponseDto>(
        data,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    
    return Results.Ok(result?.Restaurants);
}).RequireCors(MyAllowSpecificOrigins);

app.Run("http://localhost:5101");