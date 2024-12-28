using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    internal class Functions
    {
        public static double RetiredPaycheck()
        {
            return 0;
        }

        public static double SeparatedPaycheck()
        {
            return 0;
        }

        public static decimal EmployedPayAmount(int workHours, decimal rate)
        {
            return ComputeBonus(workHours) + ComputeRegularPayAmount(workHours, rate);
        }

        private static decimal ComputeBonus(int workHours)
        {
            return workHours > 40 ? 1000 : 0;
        }

        private static decimal ComputeRegularPayAmount(int workHours, decimal rate)
        {
            return rate * workHours;
        }
    }
}
