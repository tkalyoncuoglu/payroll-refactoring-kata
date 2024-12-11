using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    public interface IEmployee
    {
        decimal CalculatePayAmount();

        string Abbrv { get; }
    }
}
