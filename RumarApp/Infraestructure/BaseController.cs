using System.IO;
using System.Security.Claims;
using Core.Entities;
using Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace RumarApp.Infraestructure
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public ClaimsIdentity CurrentUser => ClaimsHelper.ClaimsIdentity;
        
        protected void ShowNotification(string message, string title, NotificationType type)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = type.ToString(),
                type = type.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}
