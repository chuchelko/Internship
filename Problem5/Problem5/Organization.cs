namespace Problem5;

using System.Text;

public class Organization
{
    public string Name { get; set; } = "Организация в Казани!!";

    private List<Branch> _branches = new List<Branch>();

    private List<Subdivision> _subdivisions = new List<Subdivision>();

    public bool AddBranch(string name)
    {
        foreach (var branch in _branches)
            if (branch.Name == name)
                return false;

        _branches.Add(new Branch() { Name = name.Trim() });
        return true;
    }

    public int AddSubdivision()
    {
        var subdivision = new Subdivision();
        _subdivisions.Add(subdivision);
        return subdivision.Number;
    }

    public Subdivision GetSubdivision(int number) => _subdivisions.FirstOrDefault(sub => sub.Number == number);

    public Branch GetBranch(string branchName) => _branches.FirstOrDefault(
        branch => branch.Name.ToLower() == branchName.Trim().ToLower());

    public bool RemoveBranch(string branchName) => _branches.Remove(GetBranch(branchName));

    public bool RemoveSubdivision(int number) => _subdivisions.Remove(GetSubdivision(number));

    public Employee AddEmployee(string fullName, string position, SalaryType salaryType, decimal salary
        , string branchName, int subdivisionNumber)
    {
        Branch branch = GetBranch(branchName);
        Subdivision subdivision = GetSubdivision(subdivisionNumber);
        Employee employee = new Employee(fullName, position, salaryType) { Branch = branch, Subdivision = subdivision, Salary = salary};
        subdivision.AddEmployee(employee, branchName);
        return employee;
    }

    public void RemoveEmployee(string fullName)
    {
        foreach(Subdivision subdivision in _subdivisions)
        {
            subdivision.RemoveEmployees(fullName);
        }
    }

    public Employee? GetEmployee(string fullName)
    {
        foreach (Subdivision subdivision in _subdivisions)
        {
            var employees = subdivision.GetAllEmployees();
            foreach (var employee in employees)
            {
                if (employee.FullName == fullName)
                {
                    return employee;
                }
            }
        }
        return null;
    }

    public string GetBranches()
    {
        var branches = _branches.OrderBy(b => b.Name).ToList();

        StringBuilder sb = new StringBuilder();
        
        foreach(Branch branch in branches)
            sb.Append(branch.Name + '\n');
        
        return sb.ToString();
    }

    public string GetBranchesWithEmployeeCount()
    {
        var branches = _branches.OrderBy(b => b.Name).ToList();
        
        StringBuilder sb = new StringBuilder();
        
        foreach (Branch branch in branches)
            sb.Append(branch.Name + ' ' + branch.GetEmployeeCount() + '\n');
        
        return sb.ToString();
    }

    public string GetSubdivisions()
    {
        var subdivisions = _subdivisions.OrderBy(s => s.Number).ToList();
        
        StringBuilder sb = new StringBuilder();
        
        foreach (Subdivision subdivision in subdivisions)
            sb.Append(subdivision.ToString() + '\n');
        
        return sb.ToString();
    }

    public string GetPayslip(string branchName, int subdivisionNumber)
    {
        Subdivision sub = _subdivisions.FirstOrDefault(sub => sub.Number == subdivisionNumber);
        
        return sub?.GetPayslip(branchName);
    }

    public string GetBranchesWithSubdivisionsAndEmployees()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach(var branch in _branches)
        {
            sb.Append(branch.Name + '\n');
            sb.Append(branch.GetSubdivisionsWithEmployeesCount());
        }
        
        return sb.ToString();
    }

    public string GetBranchesWithAverageSalaries()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (var branch in _branches)
        {
            sb.Append(branch.Name + " средняя зарплата " + branch.GetAverageSalary() +'\n');
        }
        
        return sb.ToString();
    }

    public string GetEmployeesWithSalariesGreaterThan(decimal minimalSalary)
    {
        StringBuilder sb = new StringBuilder();
        
        foreach(var sub in _subdivisions)
        {
            sb.Append(sub.EmployeesWithMinimalSalary(minimalSalary));
        }
        
        return sb.ToString();
    }

    public string GetEndedWorkingEmployees()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (var sub in _subdivisions)
        {
            sb.Append(sub.GetEndedWorkingEmployees());
        }
        
        return sb.ToString();
    }

    public string GetEmployeesWithHighestSalaries(int n)
    {
        List<Employee> employees = new List<Employee>();
        
        foreach(Subdivision subdivision in _subdivisions)
        {
            employees.AddRange(subdivision.GetAllEmployees());
        }
        
        employees = employees.OrderByDescending(emp => emp.GetMonthSalary()).ToList();
        StringBuilder sb = new StringBuilder();
        
        if (n > employees.Count)
            n = employees.Count;
        
        int i = 0;
        foreach(Employee emp in employees)
        {
            if (++i > n)
                break;
            sb.Append(emp.FullName + '\n');
        }
        
        return sb.ToString();
    }
}
