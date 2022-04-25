namespace Problem4;

internal class Credit
{
    public virtual decimal Sum { get; set; }
    public virtual void PrintSum()
    {
        Console.WriteLine(Sum);
    }
}

internal class LongCredit : Credit
{
    public override decimal Sum { 
        get { 
            return base.Sum; 
        }
        set {
            if (value <= 20000) throw new Exception();
            else base.Sum = value;
        } 
    }
    public override sealed void PrintSum()
    {
        Console.WriteLine("Long Credit");
        base.PrintSum();
    }

}
