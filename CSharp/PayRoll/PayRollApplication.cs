namespace PayRoll;

public static class PayRollApplication
{
    public static PayCheck PayAmount(Employee employee)
    {
        return new PayCheck(employee);
    }

    
}



public class PayCheck
{
    private decimal Amount { get; }
    private string ReasonCode { get; }

    public PayCheck(Employee employee)
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