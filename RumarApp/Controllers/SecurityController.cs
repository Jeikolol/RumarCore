using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using RumarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RumarApp.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<SecurityController> _logger;
        private readonly IEmailSender _emailSender;

        public SecurityController(SignInManager<User> signInManager,
            ILogger<SecurityController> logger,
            UserManager<User> userManager,
            //RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
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

        public ActionResult Register(string returnUrl)
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel param)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(param.UserName, param.Password, param.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario logeado.");
                    return RedirectToAction("Index", "Home");
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("Usuario bloqueado.");
                //    return RedirectToPage("./Lockout");
                //}
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            // Clear the existing external cookie to ensure a clean login process
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return RedirectToAction("Login", "Security");
        }

        public async Task<IActionResult> CreateUser(RegisterModel param, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            param.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User { UserName = param.UserName, Email = param.Email };
                var result = await _userManager.CreateAsync(user, param.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario creado.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(param.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = param.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //}
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        //private async Task CreateRolesandUsers()
        //{
        //    bool x = await _roleManager.RoleExistsAsync("Admin");
        //    if (!x)
        //    {
        //        // first we create Admin rool    
        //        var role = new IdentityRole();
        //        role.Name = "Admin";
        //        await _roleManager.CreateAsync(role);

        //        //Here we create a Admin super user who will maintain the website                   

        //        var user = new User();
        //        user.UserName = "default";
        //        user.Email = "default@default.com";

        //        string userPWD = "somepassword";

        //        IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

        //        //Add default User to Role Admin    
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = await _userManager.AddToRoleAsync(user, "Admin");
        //        }
        //    }

        //    // creating Creating Manager role     
        //    x = await _roleManager.RoleExistsAsync("Manager");
        //    if (!x)
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Manager";
        //        await _roleManager.CreateAsync(role);
        //    }

        //    // creating Creating Employee role     
        //    x = await _roleManager.RoleExistsAsync("Employee");
        //    if (!x)
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Employee";
        //        await _roleManager.CreateAsync(role);
        //    }
        //}
    }
}
