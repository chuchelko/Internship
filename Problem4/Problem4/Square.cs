namespace Problem4;

internal class Square : Figure
{
    public Square(double length) : base(length) { }
    protected override void area()
    {
        Area = Length * Length;
    }

    protected override void perimeter()
    {
        Perimeter = Length * 4;
    }
}
