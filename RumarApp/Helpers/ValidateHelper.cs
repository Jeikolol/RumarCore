using System.Text.RegularExpressions;

namespace RumarApp.Helpers
{
    public class ValidateHelper
    {
        public static bool IsValidDrCedula(string drCedula)
        {
            // Is it null?
            if (drCedula == null)
                return false;

            // Valid format?
            drCedula = Regex.Replace(drCedula, "[^0-9]", string.Empty); // Only keep #s.
            if (!drCedula.Length.Equals(11) || long.Parse(drCedula).Equals(0))
                return false;

            // Validate.
            var sum = 0;
            for (var i = 0; i < 10; ++i)
            {
                var n = ((i + 1) % 2 != 0 ? 1 : 2) * int.Parse(drCedula.Substring(i, 1));
                sum += n <= 9 ? n : n % 10 + 1;
            }
            var dig = (10 - sum % 10) % 10;
            return dig.Equals(int.Parse(drCedula.Substring(10, 1)));
        }
    }
}
