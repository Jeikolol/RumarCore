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
            if (User.Identity.IsAuthenticated)
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

                ClaimsHelper.BuildClaimsIdentity(result);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                   new ClaimsPrincipal(ClaimsHelper.ClaimsIdentity),
                                                   new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

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
    }
}
