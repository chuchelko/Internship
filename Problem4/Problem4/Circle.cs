namespace Problem4;

internal class Circle : Figure
{
    public Circle(double length) : base(length) { }
    protected override void area()
    {
        Area = Math.PI * Length * Length;
    }

    protected override void perimeter()
    {
        Perimeter = 2 * Math.PI * Length;
    }
}
