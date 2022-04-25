namespace Problem4.Interfaces;

internal class SquareWithInterface : IFigure
{
    public SquareWithInterface(double length)
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
        Area = Length * Length;
    }
    public void perimeter()
    {
        Perimeter = Length * 4;
    }
}
