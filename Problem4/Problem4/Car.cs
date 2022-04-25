namespace Problem4;

internal class Car
{
    public string Model { get; set; }
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public override string ToString()
    {
        return Model;
    }
}
