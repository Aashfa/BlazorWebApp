using System.Net.Http.Json;
using Entities;
using Repo.IService; // Your existing service interface

namespace YourBlazorApp.Services.ApiClients
{
    public class DealApiService : IDealService // Implement your existing interface
    {
        private readonly HttpClient _httpClient;
        private const string BaseRoute = "api/deals";

        public DealApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Deal>> GetAllDeals()
        {
            return await _httpClient.GetFromJsonAsync<List<Deal>>(BaseRoute)
                   ?? new List<Deal>();
        }

        public async Task<Deal> GetDealById(int dealId)
        {
            return await _httpClient.GetFromJsonAsync<Deal>($"{BaseRoute}/{dealId}");
        }

        public async Task<int> CreateDeal(Deal deal)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseRoute, deal);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> UpdateDeal(Deal deal)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseRoute}/{deal.DealId}", deal);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDeal(int dealId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseRoute}/{dealId}");
            return response.IsSuccessStatusCode;
        }
    }
}