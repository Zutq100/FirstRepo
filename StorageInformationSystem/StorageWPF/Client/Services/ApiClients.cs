using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StorageApi.DTO;
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

        public async Task<List<StorageMovement>> GetMovementsAsync(int itemId)
        {
            return await _httpClient.GetFromJsonAsync<List<StorageMovement>>($"api/storagemovements/item/{itemId}") ?? new List<StorageMovement>();
        }

        public async Task<StorageMovement> GetMovementByIdAsync(int movementId)
        {
            var response = await _httpClient.GetAsync($"api/storagemovements/item/{movementId}");
            return await response.Content.ReadFromJsonAsync<StorageMovement>();
        }
        public async Task UpdateMovementAsync(int movementId,StorageMovement movement)
        {
            var response = await _httpClient.PutAsJsonAsync(
        $"api/storagemovements/{movementId}", movement);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"{(int)response.StatusCode} - {errorContent}");
            }
        }

        public async Task DeleteMovementAsync(int movementId)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/storagemovements/{movementId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException("Перемещение не найдено на сервере");
            }

            response.EnsureSuccessStatusCode();
        }
        public async Task<StorageMovement> CreateMovementAsync(StorageMovement movement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/storagemovements", movement);
            return await response.Content.ReadFromJsonAsync<StorageMovement>();
        }

        public async Task<int> GetCurrentQuantityAsync(int itemId)
        {
            var item = await GetItemByIdAsync(itemId);
            return item.Quantity;
        }
    }
}
