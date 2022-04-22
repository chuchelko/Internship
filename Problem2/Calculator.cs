namespace Problem2;

internal class Calculator
{
    public void Add(int a, int b) => Console.WriteLine(a + b);
    public void Add(int a, int b, int c) => Console.WriteLine(a + b + c);
    
    //не скомпилируется, потому что одинаковая сигнатура:
    //public void Add(int a, int b)
    //{
    //    int result = a + b;
    //    Console.WriteLine($"Result is {result}");
    //}

    //public void Add(int a1, int b1)
    //{
    //    int result = a + b;
    //    Console.WriteLine($"Result is {result}");
    //}


}
