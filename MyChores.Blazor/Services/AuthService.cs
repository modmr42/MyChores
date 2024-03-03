using Blazored.LocalStorage;
using MyChores.Application.Features.Auth.Commands;
using MyChores.Application.Features.Auth.Dtos;
using MyChores.Application.Features.Auth.Queries;
using MyChores.Application.Features.Chores.Commands;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MyChores.Blazor.Services
{
    public class AuthService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly string authEndpoint = "http://localhost:6020/Auth";
        public AuthService(HttpClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<Guid?> CreateUserAsync(CreateUserCommand user)
        {
            var result = await _client.PostAsJsonAsync<CreateUserCommand>(authEndpoint, user);

            if (!result.IsSuccessStatusCode)
                return null;

            string jsonResponse = await result.Content.ReadAsStringAsync();
            var guid = JsonConvert.DeserializeObject<Guid?>(jsonResponse);

            return guid;
        }
        public async Task<LoginResponseDto?> LoginUserAsync(LoginUserQuery user)
        {
            var result = await _client.PostAsJsonAsync<LoginUserQuery>($"{authEndpoint}/Login", user);

            if (!result.IsSuccessStatusCode)
                return null;


            string jsonResponse = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto?>(jsonResponse);

            return loginResponse;
        }

    }
}
