using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace RumarApp.Helpers
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            if (value.ToString().Contains("0"))
            {
                return "";
            }

            string displayName;
            displayName = value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = value.ToString();
            }

            return displayName;
        }
    }
}
