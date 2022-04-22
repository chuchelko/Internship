namespace Library.First;

public class Car
{
    internal string name; //теперь нельзя обратиться к name из консольного проекта
    protected internal int speed;
    public void Print() => Console.WriteLine($"Name: {name}, Speed: {speed}");
    public Car(string name)
    {
        this.name = name;
    }
    public Car(int speed)
    {
        this.speed = speed;
    }
    public Car(string name, int speed)
    {
        this.name = name;
        this.speed = speed;
    }
    public Car()
    {

    }
    static Car() //вызывается даже когда создается производный класс
    {
        Console.WriteLine("static ctor"); //1 раз при создании класса
    }
}

/*internal*/public class InheritedCar : Car
{
    //если используем ниже protected internal, то вызывается Print() базового класса
    public new void Print() => Console.WriteLine(speed); //можно обращаться к speed
    public InheritedCar(string name, int speed) //: base(name, speed)
    {
    }
}
