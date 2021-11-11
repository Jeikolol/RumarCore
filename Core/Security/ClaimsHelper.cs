using Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Security
{
    public static class ClaimsHelper
    {
        public static ClaimsIdentity ClaimsIdentity { get; set; }

        public static void BuildClaimsIdentity(User result)
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, result.UserName),
                 new Claim(ClaimTypes.Email, result.Email),
            };

            ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
