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
        public Employee(string abbrv, EmployedData? employedData, OneOf<Func<EmployedData, decimal>, Func<decimal>> f)
        {
            Data = employedData;

            PayCheckBehavior = f;

            Abbrv = abbrv;
        }
       
        public string Abbrv { get; private set; }

        private OneOf<Func<EmployedData, decimal>, Func<decimal>> PayCheckBehavior;

        public EmployedData? Data {  get; private set; }

        public decimal CalculatePayAmount()
        {
            return PayCheckBehavior.Match(f => f(Data), f => f());
        }
        

        
    }
}
