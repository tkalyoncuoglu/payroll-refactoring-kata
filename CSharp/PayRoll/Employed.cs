using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    public class Employed 
    {
        private readonly decimal _rate;

        private readonly int _workHours;

        public Employed(decimal rate, int workHours)
        {
            _rate = rate;
            _workHours = workHours; 
        }

        public string Abbrv => "EMP";

        public decimal CalculatePayAmount()
        {
            return ComputeBonus() + ComputeRegularPayAmount();
        }

        private  decimal ComputeBonus()
        {
            return _workHours > 40 ? 1000 : 0;
        }

        private  decimal ComputeRegularPayAmount()
        {
            return _rate * _workHours;
        }
    }
}
