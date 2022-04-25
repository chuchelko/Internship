namespace Problem4;

internal abstract class Figure
{
    public double Area, Length, Perimeter;
    public Figure(double length)
    {
        Length = length;
        area();
        perimeter();
    }
    public void InfoFigure()
    {
        Console.WriteLine($"Длина стороны {Length}, площадь {Area}, периметр {Perimeter}");
    }
    protected abstract void area();
    protected abstract void perimeter();

}
