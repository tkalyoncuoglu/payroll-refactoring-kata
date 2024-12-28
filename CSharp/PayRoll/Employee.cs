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
        public Employee(string abbrv, EmployedData? employedData, PayRollBehavior f)
        {
            Data = employedData;

            PayCheckBehavior = f;

            Abbrv = abbrv;
        }
       
        public string Abbrv { get; private set; }

        private PayRollBehavior PayCheckBehavior;

        public EmployedData? Data {  get; private set; }

        public decimal CalculatePayAmount()
        {
            if (Data == null && PayCheckBehavior.IsT0)
                throw new InvalidOperationException("EmployedData is required but is null.");

            return PayCheckBehavior.Match(f => f(Data), f => f());
        }
        

        
    }
}
