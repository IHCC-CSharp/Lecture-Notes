namespace EmployeeLibrary;

public class Employee
{
    protected double salary;
    public int Id { get; set; }

    public double Salary
    {
        get => salary;
        set => salary = value < 15_000 ? 15_000 : value;
    }

    public override string ToString()
    {
        return "Hello. I am employee #" + Id;
    }
}