namespace Problem4.Interfaces;

internal class TriangleWithInterface : IFigure
{
    public TriangleWithInterface(double length)
    {
        Length = length;
        area();
        perimeter();
    }
    public double Length { get; set; }
    public double Area { get; set; }
    public double Perimeter { get; set; }
    public void area()
    {
        Area = Math.Sqrt(3) * Length * Length / 4;
    }
    public void perimeter()
    {
        Perimeter = Length * 3;
    }
}
