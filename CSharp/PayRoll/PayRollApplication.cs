using OneOf;

namespace PayRoll;

public static class PayRollApplication
{
    public static PayCheck PayAmount(OneOf<Employed, Retired, Separated> employee)
    {
        return new PayCheck(employee);
    }

    
}



public class PayCheck
{
    private decimal Amount { get; }
    private string ReasonCode { get; }

    public PayCheck(OneOf<Employed, Retired, Separated> employee)
    {
        Amount = employee.Match(
            employed => employed.CalculatePayAmount(),
            retired => retired.CalculatePayAmount(),
            separated => separated.CalculatePayAmount());

        ReasonCode = employee.Match(
            employed => employed.Abbrv,
            retired => retired.Abbrv,
            separated => separated.Abbrv);
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