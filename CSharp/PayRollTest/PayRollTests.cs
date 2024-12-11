using NUnit.Framework;
using PayRoll;

namespace PayRollTest;

public class PayRollTests
{
    private const int IRRELEVANT = 53;

    [Test]
    public void without_bonus()
    {
        var employee = Employee.CreateEmployee(100, false, false, 30);
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(3000, "EMP"), payCheck);
    }
    
    [Test]
    public void with_bonus()
    {
        var employee = Employee.CreateEmployee(10, false, false, 41);
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(1410, "EMP"), payCheck);
    }
    
    [Test]
    public void retired()
    {
        var employee = Employee.CreateEmployee(IRRELEVANT, false, true, IRRELEVANT);
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(0, "RET"), payCheck);
    }
    
    [Test]
    public void separated()
    {
        var employee = Employee.CreateEmployee(IRRELEVANT, true, false, IRRELEVANT);
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(0, "SEP"), payCheck);
    }
}