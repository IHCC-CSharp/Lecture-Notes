namespace EmployeeLibrary;

public class CommissionEmployee : Employee
{
    private double _commissionRate;
    public double CommissionRate
    {
        get => _commissionRate;
        set
        {
            _commissionRate = value;
            salary = 0;
        }
    }

    public override string ToString()
    {
        return base.ToString() + " and my commission rate is " + _commissionRate;
    }
}