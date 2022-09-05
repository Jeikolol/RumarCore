using Core.Entities;
using Microsoft.EntityFrameworkCore;
using RumarApp.Helpers;
using RumarApp.Infraestructure;
using RumarApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseMigrations.Data;
using Core.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RumarApp.Services
{
    public class SecurityService : Service, ISecurityService
    {
        private readonly IHttpContextAccessor _accessorAccessor;
        
        public SecurityService(ApplicationDbContext _Database, 
            IHttpContextAccessor accessoraccessor) : base(_Database)
        {
            _accessorAccessor = accessoraccessor;
        }

        public async Task<User> CreateUserAsync(RegisterModel parameter)
        {
            var hash = PasswordHash.CreatePassword(parameter.Password);

            var userToCreate = new User
            {
                UserName = parameter.UserName,
                Password = hash,
                Email = parameter.Email,
                FirstName = parameter.FirstName,
                LastName = parameter.LastName,
                Identification = parameter.Identification,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                PhoneNumber = parameter.PhoneNumber,
                MobileNumber = parameter.MobileNumber,
                Address = parameter.Address,
            };

            Database.Add(userToCreate);
            await Database.SaveChangesAsync();

            return userToCreate;
        }

        public async Task<User> Login(string userName)
        {
            var user = await Database.Users
                .Where(x => x.UserName == userName)
                .FirstOrDefaultAsync();

            return user;
        }

        //public async Task IncrementarIntentosYChequearIntentosMaximos(User user, string passsword, int intentoMaximo)
        //{
        //    var usuarioParaActualizar = await Database.Users
        //        .Where(x => x.Id == user.Id)
        //        .FirstOrDefaultAsync();

        //    usuarioParaActualizar.Intentos++;

        //    if (usuarioParaActualizar.Intentos > intentoMaximo)
        //    {
        //        usuarioParaActualizar.Activo = false;
        //    }

        //    Database.Update(usuarioParaActualizar);

        //    await Database.SaveChangesAsync();
        //}

        //public async Task ResetearIntentosDeUsuario(User user)
        //{
        //    if (user.Intentos > 0)
        //    {
        //        var usuarioParaActualizar = await Database.Users
        //            .Where(x => x.Id == user.Id)
        //            .FirstOrDefaultAsync();

        //        user.Intentos = 0;
        //        usuarioParaActualizar.Intentos = 0;

        //        Database.Update(usuarioParaActualizar);
        //        await Database.SaveChangesAsync();
        //    }
        //}

        public void LoadSession()
        {
            var accessor = _accessorAccessor.HttpContext;

            if (accessor != null)
            {
                var claims = accessor.User.Claims;

                var loginResult = new LoginResult
                {
                    UserId = Int32.Parse(claims.FirstOrDefault(x => x.Type == "UserId")?.Value),
                    UserName = claims.FirstOrDefault(x => x.Type == "UserName")?.Value,
                    FullName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                };

                ClaimsHelper.CurrentUser.UserData = loginResult;
                ClaimsHelper.CurrentUser.ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }

    public interface ISecurityService : IService
    {
        Task<User> CreateUserAsync(RegisterModel parameter);
        Task<User> Login(string userName);
        //Task IncrementarIntentosYChequearIntentosMaximos(User user, string passsword, int intentoMaximo);
        //Task ResetearIntentosDeUsuario(User user);
        void LoadSession();
    }
}
