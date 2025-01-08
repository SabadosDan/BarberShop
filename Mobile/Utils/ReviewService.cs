using System.Net.Http.Json;
using WebAPI.Models;

public class ReviewService
{
    private readonly HttpClient _httpClient;
    private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
         ? "http://10.0.2.2:5145"
         : "http://localhost:5145";

    public ReviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(ApiUrl);
    }

    public ReviewService()
    {

    }

    public async Task<List<Review>> GetReviewsByBarberIdAsync(int barberId)
    {
        var response = await _httpClient.GetAsync($"api/reviews/{barberId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Review>>();
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        else
        {
            response.EnsureSuccessStatusCode();
            return null;
        }
    }

    public async Task<double?> GetAverageRatingAsync(int barberId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Rating/{barberId}");

            if (response.IsSuccessStatusCode)
            {
                var ratings = await response.Content.ReadFromJsonAsync<List<int>>();

                if (ratings != null && ratings.Any())
                {
                    return ratings.Average();
                }
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task PostReviewAsync(Review review)
    {
        var response = await _httpClient.PostAsJsonAsync("api/reviews", review);
        response.EnsureSuccessStatusCode();
    }
}
