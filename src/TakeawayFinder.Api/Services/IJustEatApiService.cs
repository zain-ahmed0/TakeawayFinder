namespace TakeawayFinder.Api;

public interface IJustEatApiService
{
    static abstract Task<String> GetData(
        string postcode);
}