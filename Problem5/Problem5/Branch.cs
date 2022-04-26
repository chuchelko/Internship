using System.Text;

namespace Problem5;

public class Branch
{
    public string Name { get; set; }
    private List<Subdivision> _subdivisions = new List<Subdivision>();

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(Subdivision subdivision in _subdivisions)
            stringBuilder.Append(subdivision.ToString());
        return stringBuilder.ToString();
    }
    public void AddSubdivision(Subdivision subdivision) => _subdivisions.Add(subdivision);

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
        foreach (var sub in _subdivisions)
        {
            total += sub.GetTotalSalary(Name);
            empCount += sub.GetCountOfEmployees(Name);
        }
        return total / _subdivisions.Count;
    }

}
