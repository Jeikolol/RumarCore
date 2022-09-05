using Core.Entities;
using Core.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RumarApp.Helpers;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RumarApp.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel param)
        {
            if (ModelState.IsValid)
            {
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _securityService.Login(param.UserName);

                if (result == null)
                {
                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }
                
                if (!PasswordHash.ValidatePassword(param.Password, result.Password))
                {
                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }

                SignIn(result);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async void SignIn(User user)
        {
            ClaimsHelper.BuildClaimsIdentity(user);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(ClaimsHelper.CurrentUser.ClaimsIdentity),
                new AuthenticationProperties { IsPersistent = true });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Security");
        }

        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            return View(new RegisterModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel param, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                if(!ValidateHelper.IsValidDrCedula(param.Identification))
                {
                    ShowNotification("Cedula Invalida", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }

                var result = await _securityService.CreateUserAsync(param);

                if (result != null)
                {
                    ShowNotification("Usuario Creado Correctamente", "Mantenimiento de Usuarios", NotificationType.success);

                    return LocalRedirect(returnUrl);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadSession()
        {
            _securityService.LoadSession();

            return Json(new {});
        }
    }
}
