using System.Security.Claims;

namespace Core.Security
{
    public class LoginSessionData
    {
        public LoginResult UserData { get; set; } = new();
        public ClaimsIdentity ClaimsIdentity { get; set; } = new();

    }
}
