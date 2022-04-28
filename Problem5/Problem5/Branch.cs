namespace Problem5;

using System.Text;

public class Branch
{
    public string Name { get; set; }

    private List<Subdivision> _subdivisions = new List<Subdivision>();
    
    public void AddSubdivision(Subdivision subdivision) => _subdivisions.Add(subdivision);

    public int GetEmployeeCount()
    {
        int count = 0;
        foreach (var sub in _subdivisions)
        {
            count += sub.GetCountOfEmployees(Name);
        }
        return count;
    }

    public string GetSubdivisionsWithEmployeesCount()
    {
        StringBuilder sb = new StringBuilder();

        foreach(var subdivision in _subdivisions)
            sb.Append($"Подразделение {subdivision.Number}: {subdivision.GetCountOfEmployees(Name)} чел\n");
        
        return sb.ToString();
    }

    public decimal GetAverageSalary()
    {
        decimal total = 0;
        int empCount = 0;

        foreach (var subdivision in _subdivisions)
        {
            total += subdivision.GetTotalSalary(Name);
            empCount += subdivision.GetCountOfEmployees(Name);
        }

        if (_subdivisions.Count == 0)
            return 0m;
        return total / empCount;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (Subdivision subdivision in _subdivisions)
            stringBuilder.Append(subdivision.ToString());
        
        return stringBuilder.ToString();
    }
}
