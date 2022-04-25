namespace Problem4.Interfaces;

internal interface IFigure
{
    double Length { get; set; }
    double Area { get; set; }
    double Perimeter { get; set; }
    public void InfoFigure()
    {
        Console.WriteLine($"Длина стороны {Length}, площадь {Area}, периметр {Perimeter}");
    }
    void area();
    void perimeter();
}
