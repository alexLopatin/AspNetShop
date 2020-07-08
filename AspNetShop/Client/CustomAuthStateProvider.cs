using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Blazored.LocalStorage;
using System.Net.Http;

namespace AspNetShop.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorage;
        private HttpClient Http;
        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient client)
        {
            _localStorage = localStorage;
            Http = client;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("JWT");
            Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            return await Task.FromResult(new AuthenticationState(null));
        }
    }
}
