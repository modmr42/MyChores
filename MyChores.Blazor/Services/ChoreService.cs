using Blazored.LocalStorage;
using MyChores.Application.Features.Chores.Commands;
using MyChores.Application.Features.Chores.Dtos;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace MyChores.Blazor.Services
{
    public class ChoreService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly string choresEndpoint = "http://localhost:6020/Chore";
        public ChoreService(HttpClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }
        public async Task<Guid?> CreateAsync(CreateChoreCommand chore)
        {
            var result = await _client.PostAsJsonAsync<CreateChoreCommand>(choresEndpoint, chore);

            string jsonResponse = await result.Content.ReadAsStringAsync();
            var guid = JsonConvert.DeserializeObject<Guid?>(jsonResponse);

            return guid;
        }
        public async Task<ChoreDto?> GetAsync(string guid)
        {
            var result = await _client.GetAsync($"{choresEndpoint}/{guid}");
            if (!result.IsSuccessStatusCode)
                throw new Exception("fuck");

            string jsonResponse = await result.Content.ReadAsStringAsync();
            var chore = JsonConvert.DeserializeObject<ChoreDto>(jsonResponse);

            return chore;
        }
        public async Task<List<ChoreDto>?> GetAllAsync()
        {
            var jwt = await _localStorageService.GetItemAsync<string>("token");
            // Add the JWT token to the Authorization header
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var result = await _client.GetAsync($"{choresEndpoint}");

            if (!result.IsSuccessStatusCode)
                return null;

            string jsonResponse = await result.Content.ReadAsStringAsync();
            var chores = JsonConvert.DeserializeObject<List<ChoreDto>?>(jsonResponse);

            return chores;

        }
        public async Task<Guid?> UpdateAsync(UpdateChoreCommand chore)
        {
            var result = await _client.GetAsync($"{choresEndpoint}");
            string jsonResponse = await result.Content.ReadAsStringAsync();
            var guid = JsonConvert.DeserializeObject<Guid?>(jsonResponse);

            return guid;
        }
        public async Task DeleteAsync(string guid)
        {
            var result = await _client.DeleteAsync($"{choresEndpoint}/{guid}");
            string jsonResponse = await result.Content.ReadAsStringAsync();
        }

    }
}
