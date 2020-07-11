using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.Form
{
    public class Register
    {
        public string UserName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string SecondName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool RememberMe { get; set; } = false;
        public string Password { get; set; }
    }
}
