using NewsApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Net.WebRequestMethods;

namespace NewsApi.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NewsService(HttpClient httpClient, IConfiguration apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey["NewsApi:ApiKey"];
        }

        public async Task<List<News>> GetNewsAsync(string key, string language)
        {
            var response = await _httpClient.GetStringAsync($"https://newsapi.org/v2/everything?q={key}&language={language}&apikey={_apiKey}");

            return JsonSerializer.Deserialize<List<News>>(response);
        }
    }
}
