using Blazored.LocalStorage;
using FilRougeCore.Models;
using FilRougeFront.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace FilRougeFront.Services
{
    public class SessionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;
        private readonly ILocalStorageService _localStorage;

        public SessionService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["APIUrlHttp"] + "/api/Session";
            _localStorage = localStorage;
        }

        public async Task<List<Session>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<Session>>(_baseApiRoute);

            return response!;



        }

        public async Task<Session?> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Session>(_baseApiRoute + $"/{id}");
            return result;
        }

        public async Task<bool> Post(Session session)
        {
            var stringSession = JsonConvert.SerializeObject(session);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
            request.Content = new StringContent(stringSession, Encoding.UTF8, "application/json");
            return await SendRequest(request);
        }

        public async Task<bool> Put(Session session)
        {
            var stringSession = JsonConvert.SerializeObject(session);
            var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute + $"/{session.Id}");
            request.Content = new StringContent(stringSession, Encoding.UTF8, "application/json");
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

        public async Task Put(SessionEditDTO? sessionToEdit)
        {
            if (sessionToEdit != null)
            {
                var stringSession = JsonConvert.SerializeObject(sessionToEdit);
                var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
                request.Content = new StringContent(stringSession, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }

        public async Task Post(SessionEditDTO? sessionToEdit)
        {
            if (sessionToEdit != null)
            {
                var stringSession = JsonConvert.SerializeObject(sessionToEdit);
                var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
                request.Content = new StringContent(stringSession, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }
    }
}
