using Blazored.LocalStorage;
using FilRougeCore.Models;
using FilRougeFront.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace FilRougeFront.Services
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;
        private readonly ILocalStorageService _localStorage;

        public RoomService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["APIUrlHttp"] + "/api/rooms";
            _localStorage = localStorage;
        }

        public async Task<List<Room>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Room>>(_baseApiRoute);
            return result!;
        }

        public async Task<Room?> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Room>(_baseApiRoute + $"/{id}");
            return result;
        }

        public async Task<bool> Post(Room room)
        {
            var stringRoom = JsonConvert.SerializeObject(room);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
            request.Content = new StringContent(stringRoom, Encoding.UTF8, "application/json");
            return await SendRequest(request);
        }

        public async Task<bool> Put(Room room)
        {
            var stringRoom = JsonConvert.SerializeObject(room);
            var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
            request.Content = new StringContent(stringRoom, Encoding.UTF8, "application/json");
            return await SendRequest(request);
        }

        public async Task<bool> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _baseApiRoute + $"/{id}");
            return await SendRequest(request);
        }

        public async Task<bool> SendRequest(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetJWT());
            var result = await _httpClient.SendAsync(request);
            return result.IsSuccessStatusCode;
        }

        private async Task<string> GetJWT()
        {
            return await _localStorage.GetItemAsync<string>("jwt");
        }

        public async Task Put(RoomEditDTO? roomToEdit)
        {
            if (roomToEdit != null)
            {
                var stringRoom = JsonConvert.SerializeObject(roomToEdit);
                var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
                request.Content = new StringContent(stringRoom, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }

        public async Task Post(RoomEditDTO? roomToEdit)
        {
            if (roomToEdit != null)
            {
                var stringRoom = JsonConvert.SerializeObject(roomToEdit);
                var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
                request.Content = new StringContent(stringRoom, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }

    }
}
