using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StorageWPF.Client.Models;

namespace StorageWPF.Client.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        // Методы для работы с товарами
        public async Task<List<StorageItem>> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StorageItem>>("api/storageitems") ?? new List<StorageItem>();
        }

        public async Task<StorageItem?> GetItemByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StorageItem>($"api/storageitems/{id}");
        }

        public async Task<StorageItem> CreateItemAsync(StorageItem item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/storageitems", item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StorageItem>() ?? throw new Exception("Error creating item");
        }

        public async Task UpdateItemAsync(StorageItem item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/storageitems/{item.Id}", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/storageitems/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Методы для работы с движениями товаров
        public async Task<List<StorageMovement>> GetMovementsAsync(int itemId)
        {
            return await _httpClient.GetFromJsonAsync<List<StorageMovement>>($"api/storagemovements/item/{itemId}") ?? new List<StorageMovement>();
        }

        public async Task<StorageMovement> CreateMovementAsync(StorageMovement movement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/storagemovements", movement);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StorageMovement>() ?? throw new Exception("Error creating movement");
        }
    }
}
