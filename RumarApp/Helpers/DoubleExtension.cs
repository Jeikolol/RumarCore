using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Helpers
{
    public static class DoubleExtension
    {
        public static double RoundDouble(this double value)
        {
            return Math.Round(value);
        }
    }
}
