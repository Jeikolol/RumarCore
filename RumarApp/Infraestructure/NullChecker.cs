using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Infraestructure
{
    public static class NullChecker
    {
        public static bool IsNull(object value)
        {
            return value == null;
        }

        public static bool IsNotNull(object value)
        {
            return value != null;
        }
    }
}
