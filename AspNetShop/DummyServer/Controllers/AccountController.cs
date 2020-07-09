using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspNetShop.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AspNetShop.DummyServer.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }
        [Authorize]
        [HttpGet]
        public string GetName()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [Authorize]
        [HttpGet]
        public void LogOut()
        {
            Console.WriteLine("DIY");
        }
        [AllowAnonymous]
        [HttpPost]
        public string Login(AspNetShop.Shared.Form.Login viewModel)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, viewModel.UserName)
            };
            
            // 3. Генерируем JWT.
            var token = new JwtSecurityToken(
                issuer: "https://localhost",
                audience: "https://localhost",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials( 
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RANDOM_KEY_MUST_NOT_BE_SHARED")),
                    SecurityAlgorithms.HmacSha256));
 
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;

        }
        [AllowAnonymous]
        [HttpPost]
        public string Register(AspNetShop.Shared.Form.Login viewModel)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, viewModel.UserName)
            };

            // 3. Генерируем JWT.
            var token = new JwtSecurityToken(
                issuer: "https://localhost",
                audience: "https://localhost",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RANDOM_KEY_MUST_NOT_BE_SHARED")),
                    SecurityAlgorithms.HmacSha256));

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;

        }
    }
}
