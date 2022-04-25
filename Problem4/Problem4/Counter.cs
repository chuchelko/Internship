namespace Problem4;

internal class Counter
{
    public int Seconds { get; set; }
    public static implicit operator int(Counter counter)
    {
        return counter.Seconds;
    }
    public static implicit operator Counter(int seconds)
    {
        return new Counter() { Seconds = seconds };
    }
}
