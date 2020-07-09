using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.Form
{
    public class Login
    {
        public string UserName { get; set; } = "";
        public bool RememberMe { get; set; } = false;
        public string PasswordHash { get; set; }
    }
}
