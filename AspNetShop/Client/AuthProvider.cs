using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AspNetShop.Client
{
    public class AuthProvider : IAuthProvider
    {
        private ILocalStorageService _localStorage;
        private NavigationManager _navMan;
        public AuthProvider(ILocalStorageService localStorage, NavigationManager navMan)
        {
            _localStorage = localStorage;
            _navMan = navMan;
        }
        public async Task<T> AuthAction<T>(HttpClient Http, Func<Task<T>> unAuthAction)
        {
            var token = await _localStorage.GetItemAsync<string>("JWT");
            Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return await Task.Run(unAuthAction);
        }

        public async Task LogOut(HttpClient Http)
        {
            var token = await _localStorage.GetItemAsync<string>("JWT");
            Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await Http.GetAsync("account/logout");
            await _localStorage.RemoveItemAsync("JWT");
            _navMan.NavigateTo("/", true);
        }
    }
}
