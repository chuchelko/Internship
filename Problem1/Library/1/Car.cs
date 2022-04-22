namespace Library.First;

public class Car
{
    public string name;
    public int speed;
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
}
