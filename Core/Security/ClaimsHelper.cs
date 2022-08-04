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
                 new(ClaimTypes.Name, result.UserName),
                 new(ClaimTypes.Email, result.Email),
                 new("UserId", $"{result.Id}"),
            };

            ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
