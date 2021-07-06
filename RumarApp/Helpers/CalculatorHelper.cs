using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Helpers
{
    public class CalculatorHelper
    {

        public static decimal percentageOneValue(decimal value)
        {
            if (value == 0)
            {
                return value;
            }

            return value / 100;
        }

        public static decimal percentageTwoValue(decimal amount, decimal percentage)
        {
            percentage = percentageOneValue(percentage);

            return Decimal.Multiply(amount, percentage);
        }
    }
}
