namespace Problem4;

internal class Triangle : Figure
{
    public Triangle(double length) : base(length) { }
    protected override void area()
    {
        Area = Math.Sqrt(3) * Length * Length / 4;
    }

    protected override void perimeter()
    {
        Perimeter = Length * 3;
    }
}
