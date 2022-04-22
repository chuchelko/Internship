namespace Problem2;

//По умолчанию у класса internal, у методов и полей private
class State
{
    string name;
    void Print()
    {
        Console.WriteLine(name);
    }
    int defaultVar; //внутри текущего
    private int privateVar; //внутри текущего класса
    protected int protectedVar; //внутри текущего класса + внутри производных
    internal int internalVar; //только внутри сборки
    protected internal int protectedInternalVar; //толкьо внутри сборки + производные в другой сборке
    public int publicVar; //везде
    void defaultMethod() => Console.WriteLine($"defaultVar = {defaultVar}");
    private void privateMethod() => Console.WriteLine($"privateVar = {privateVar}");
    protected void protectedMethod() => Console.WriteLine($"protectedVar = {protectedVar}");
    internal void internalMethod() => Console.WriteLine($"internalVar = {internalVar}");
    protected internal void protectedInternalMethod() => Console.WriteLine($"protectedInternalVar = {protectedInternalVar}");
    public void publicMethod() => Console.WriteLine($"publicVar = {publicVar}");

}
