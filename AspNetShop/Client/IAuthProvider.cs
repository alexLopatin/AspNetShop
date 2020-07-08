using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetShop.Client
{
    public interface IAuthProvider
    {
        public Task<T> AuthAction<T>(HttpClient Http, Func<Task<T>> unAuthAction);
        public Task LogOut(HttpClient Http);
    }
}
