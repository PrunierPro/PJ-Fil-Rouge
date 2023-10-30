using Blazored.LocalStorage;
using FilRougeCore.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace FilRougeFront.Services
{
    public class ActivityService: IActivityService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;
        private readonly ILocalStorageService _localStorage;

        public ActivityService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["APIUrlHttp"] + "/api/Activity";
            _localStorage = localStorage;
        }

        public async Task<Activity?> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Activity>(_baseApiRoute + $"/{id}");
            return result;
        }

        public async Task<List<Activity>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Activity>>(_baseApiRoute);
            return response!;
        }

        public async Task<bool> Post(Activity activity)
        {
            var stringActivity = JsonConvert.SerializeObject(activity);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseApiRoute);
            request.Content = new StringContent(stringActivity, Encoding.UTF8, "application/json");
            return await SendRequest(request);
        }

        public async Task<bool> Put(Activity activity)
        {
            var stringActivity = JsonConvert.SerializeObject(activity);
            var request = new HttpRequestMessage(HttpMethod.Put, _baseApiRoute);
            request.Content = new StringContent(stringActivity, Encoding.UTF8, "application/json");
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
    }
}
