using System.Collections;
using System.Text;

namespace Problem5;

public class Subdivision
{
    private static int _count = 0;

    public int Number;
    
    private Dictionary<string, List<Employee>> _employees = new();
    
    public Subdivision()
    {
        _count++;
        Number = _count;
    }
    
    public void AddEmployee(Employee emp, string branchName)
    {
        branchName = branchName.Trim();
    
        if(!_employees.ContainsKey(branchName))
            _employees.Add(branchName, new List<Employee>());
        
        _employees[branchName].Add(emp);
    }

    public void RemoveEmployees(string fullName)
    {
        foreach(var list in _employees.Values)
        {
            foreach (Employee emp in list)
                if (emp.FullName == fullName)
                    list.Remove(emp);
        }
    }

    public void ChangeTypeAndSalary(string fullName, SalaryType type, decimal salary)
    {
        foreach (var list in _employees.Values)
        {
            foreach (Employee emp in list)
                if (emp.FullName == fullName)
                {
                    emp.Salary = salary;
                    emp.SalaryType = type;
                }
        }
    }

    public int GetCountOfEmployees(string branchName)
    {
        if(_employees.ContainsKey(branchName))
            return _employees[branchName].Count;

        return 0;
    }

    public string GetPayslip(string branchName)
    {
        if (!_employees.ContainsKey(branchName))
            return "Подразделения в филиале не существует";
        
        var orderedList = _employees[branchName].OrderBy(b => b.FullName).ToList();
        StringBuilder sb = new StringBuilder();
        
        foreach (Employee emp in orderedList)
            sb.Append($"{emp.FullName} зарплата {emp.GetMonthSalary()} рублей\n");
        
        return sb.ToString();
    }

    public decimal GetTotalSalary(string branchName)
    {
        decimal total = 0;
        if(!_employees.ContainsKey(branchName))
            return total;
        
        foreach (Employee emp in _employees[branchName])
        {
            total += emp.GetMonthSalary();
        }
        
        return total;
    }

    public string EmployeesWithMinimalSalary(decimal minimalSalary)
    {
        StringBuilder sb = new StringBuilder();
    
        foreach(var emp in _employees)
        {
            var employees = emp.Value;
        
            foreach(var employee in employees)
                if(employee.GetMonthSalary() > minimalSalary)
                    sb.Append(employee.FullName + '\n');
        }
        
        return sb.ToString();
    }

    public string GetEndedWorkingEmployees()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (var emp in _employees)
        {
            var employees = emp.Value;
        
            foreach (var employee in employees)
                if (employee.HoursWorked == ConstantsManager.HoursInMonth)
                    sb.Append(employee.FullName + '\n');
        }
        
        return sb.ToString();
    }

    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();
    
        foreach (var employee in _employees)
        {
            employees.AddRange(employee.Value);
        }
        
        return employees;
    }

    public override string ToString()
    {
        return "Подразделение " + Number;
    }
}