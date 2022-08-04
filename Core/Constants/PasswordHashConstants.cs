using System;
using System.Text;

namespace Core.Constants
{
    public class PasswordHashConstants
    {
        public const string DefaultUserPassword = "admin.123";
        public const string HashedAdministratorPassword = "1000:o/aziZjsVx7sr4RzrtPHNs2AkP5LGuhH:txBYU1u3kkEktiP64gKan99vXohED85c";

        public static string GenerateRandomPassword(int length = 8)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();
            var random = new Random();

            while (0 < length--)
            {
                res.Append(valid[random.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}
