namespace TakeawayFinder.Api;

public class JustEatApiService : IJustEatApiService
{
    static HttpClient client = new HttpClient();

    public static async Task<string> GetData(string postcode)
    {
        using HttpResponseMessage response = await client.GetAsync($"https://uk.api.just-eat.io/restaurants/bypostcode/{postcode}");
        
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}