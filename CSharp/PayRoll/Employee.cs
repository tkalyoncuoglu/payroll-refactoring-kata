using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    public class Employee
    {
        public Employee(EmployedData? employedData, OneOf<Func<EmployedData, decimal>, Func<decimal>> f)
        {
            Data = employedData;

            PayCheckBehavior = f;
        }
        public class EmployedData
        {
            public decimal Rate { get; set; }

            public int WorkHours { get; set; }
        }

        private OneOf<Func<EmployedData, decimal>, Func<decimal>> PayCheckBehavior;

        public EmployedData? Data {  get; private set; }

        public decimal Paycheck()
        {
            return PayCheckBehavior.Match(f => f(Data), f => f());
        }
        

        
    }
}
