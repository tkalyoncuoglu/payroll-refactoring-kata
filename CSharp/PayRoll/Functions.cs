using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    [GenerateOneOf]
    public partial class PayRollBehavior : OneOfBase<Func<EmployedData, decimal>, Func<decimal>> 
    {
    }
    public class EmployedData
    {
        public decimal Rate { get; set; }

        public int WorkHours { get; set; }
    }
    public static class Functions
    {
        public static decimal RetiredPaycheck()
        {
            return 0;
        }

        public static decimal SeparatedPaycheck()
        {
            return 0;
        }

        public static decimal EmployedPaycheck(EmployedData data)
        {
            return ComputeBonus(data.WorkHours) + ComputeRegularPayAmount(data.WorkHours, data.Rate);
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
