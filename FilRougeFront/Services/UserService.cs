﻿using FilRougeCore.DTOs;
using FilRougeCore.Models;
using FilRougeFront.DTOs;
using System.Net.Http.Json;

namespace FilRougeFront.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;

        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["APIUrlHttp"] + "/api/Authentication";
        }

        public async Task<bool> Register(User user)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRoute + $"/Register", user);
            return result.IsSuccessStatusCode;
        }

        public async Task<UserLoginDTO> Login(LoginRequestDTO user)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRoute + $"/Login", user);
            if (result.IsSuccessStatusCode)
            {
                var dto = await result.Content.ReadFromJsonAsync<UserLoginDTO>();
                return dto;
            }
            return null;

        }

        public async Task<User> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<User>(_baseApiRoute + $"/User/{id}");
            return result;
        }
    }
}
