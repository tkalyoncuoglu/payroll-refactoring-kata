using NUnit.Framework;
using PayRoll;
using System;

namespace PayRollTest;

public class PayRollTests
{
    private const int IRRELEVANT = 53;

    
    [Test]
    public void without_bonus()
    {
        var employee = new Employee("EMP", new EmployedData() { WorkHours = 30, Rate = 100 }, (System.Func<EmployedData, decimal>) (Functions.EmployedPaycheck));
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(3000, "EMP"), payCheck);
    }
    
    [Test]
    public void with_bonus()
    {
        var employee = new Employee("EMP", new EmployedData() { WorkHours = 41, Rate = 10 }, (System.Func<EmployedData, decimal>)(Functions.EmployedPaycheck));
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(1410, "EMP"), payCheck);
    }
    
    [Test]
    public void retired()
    {
        var employee = new Employee("RET", null, (System.Func<decimal>) (Functions.RetiredPaycheck));
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(0, "RET"), payCheck);
    }
    
    [Test]
    public void separated()
    {
        var employee = new Employee("SEP", null, (System.Func<decimal>)(Functions.SeparatedPaycheck));
        
        var payCheck  = PayRollApplication.PayAmount(employee);
        
        Assert.AreEqual(new PayCheck(0, "SEP"), payCheck);
    }
}