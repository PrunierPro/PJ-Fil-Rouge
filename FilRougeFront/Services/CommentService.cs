using Blazored.LocalStorage;
using FilRougeCore.Models;
using FilRougeFront.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace FilRougeFront.Services
{
    public class CommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;
        private readonly ILocalStorageService _localStorage;

        public CommentService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["APIUrlHttp"] + "/api/Comment";
            _localStorage = localStorage;
        }

        public async Task<List<Comment>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<Comment>>(_baseApiRoute);

            return response!;



        }

        public async Task<Comment?> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Comment>(_baseApiRoute + $"/{id}");
            return result;
        }

        public async Task<bool> Post(Comment comment)
        {
            var stringComment = JsonConvert.SerializeObject(comment);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
            request.Content = new StringContent(stringComment, Encoding.UTF8, "application/json");
            return await SendRequest(request);
        }

        public async Task<bool> Put(Comment comment)
        {
            var stringComment = JsonConvert.SerializeObject(comment);
            var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
            request.Content = new StringContent(stringComment, Encoding.UTF8, "application/json");
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

        public async Task Put(CommentEditDTO? commentToEdit)
        {
            if (commentToEdit != null)
            {
                var stringComment = JsonConvert.SerializeObject(commentToEdit);
                var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
                request.Content = new StringContent(stringComment, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }

        public async Task Post(CommentEditDTO? commentToEdit)
        {
            if (commentToEdit != null)
            {
                var stringComment = JsonConvert.SerializeObject(commentToEdit);
                var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
                request.Content = new StringContent(stringComment, Encoding.UTF8, "application/json");
                await SendRequest(request);
            }
        }
    }
}
