namespace Problem5;

public delegate decimal GetSalary(decimal salary, int hoursWorked);

public class Employee
{
    private static int _count = 0;
    
    public int Id { get; }
    
    public string FullName { get; }
    
    public string Position { get; }
    
    public SalaryType SalaryType { get; set; }
    
    public Subdivision Subdivision { get; init; }
    
    public Branch Branch { get; init; }
    
    public int HoursWorked { get; private set; }
    
    public decimal Salary { get; set; }

    private GetSalary getSalary;

    public Employee(string fullName, string position, SalaryType salaryType) : this()
    {
        FullName = fullName;
        Position = position;
        SalaryType = salaryType;
    }
    
    private Employee()
    {
        _count++;
        Id = _count;
    }
    
    public void AddHours(int hours)
    {
        if (hours < 0 || hours + HoursWorked > ConstantsManager.HoursInMonth)
            throw new Exception();
        HoursWorked += hours;
    }
    
    private decimal GetSalaryMonthlyType(decimal salary, int hoursWorked)
    {
        return salary / ConstantsManager.HoursInMonth * hoursWorked;
    }

    private decimal GetSalaryHourlyType(decimal salary, int hoursWorked)
    {
        return salary * hoursWorked;
    }

    public decimal GetMonthSalary()
    {
        if (SalaryType == SalaryType.Monthly)
            getSalary = GetSalaryMonthlyType;
        else
            getSalary = GetSalaryHourlyType;

        return getSalary(Salary, HoursWorked);
    }
}

public enum SalaryType
{
    Monthly,
    Hourly
}