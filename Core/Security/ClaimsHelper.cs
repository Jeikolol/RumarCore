using System;
using Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Security
{
    public static class ClaimsHelper
    {
        public static LoginSessionData CurrentUser { get; set; } = new();

        public static void BuildClaimsIdentity(User result)
        {
            CurrentUser = new LoginSessionData();

            var claims = new List<Claim>
            {
                 new("UserName", result.UserName),
                 new(ClaimTypes.Name, result.FullName),
                 new(ClaimTypes.Email, result.Email),
                 new("UserId", $"{result.Id}"),
                 new("UserData", $"{result}"),
            };

            var claim = claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            
            var userId = Int32.Parse(claim);

            var loginResult = new LoginResult
            {
                UserId = userId,
                UserName = claims.FirstOrDefault(x => x.Type == "UserName")?.Value,
                FullName = claims.FirstOrDefault(x => x.Type == "FullName")?.Value
            };

            CurrentUser.UserData = loginResult;
            CurrentUser.ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
