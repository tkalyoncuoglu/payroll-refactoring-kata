namespace PayRoll;

public static class PayRollApplication
{
    public static PayCheck PayAmount(IEmployee employee)
    {
        return new PayCheck(employee);
    }

    
}

public class Employee
{
    
    public static IEmployee CreateEmployee(int rate, bool separated, bool retired, int workHours)
    {
        if (separated)
            return new Separated();
        else if(retired)
            return new Retired();
        return new Employed(rate, workHours);
    }

    
}

public class PayCheck
{
    private decimal Amount { get; }
    private string ReasonCode { get; }

    public PayCheck(IEmployee employee)
    {
        Amount = employee.CalculatePayAmount();
        ReasonCode = employee.Abbrv;
    }

    public PayCheck(decimal amount, string reaseonCode)
    {
        Amount = amount;
        ReasonCode = reaseonCode;
    }

    public override string ToString()
    {
        return ReasonCode + " " + Amount;
    }

    private bool Equals(PayCheck other)
    {
        return Amount == other.Amount && ReasonCode == other.ReasonCode;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((PayCheck)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, ReasonCode);
    }
}