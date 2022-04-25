namespace Problem4.Interfaces;

internal class CircleWithInterface : IFigure
{
    public CircleWithInterface(double length)
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
        Area = Math.PI * Length * Length;
    }
    public void perimeter()
    {
        Perimeter = 2 * Math.PI * Length;
    }
}
