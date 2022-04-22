namespace Problem1;

public class Motorcycle
{
    public string name;
    public void SetDriverName(string name)
    {
        name = name; //ничего не происходит, потому что name в конструкторе перекрывает поле
    }
    public int driverIntensity;
    public Motorcycle(string name)
    {
        this.name = name;
    }

    public Motorcycle(int driverIntensity)
    {
        this.driverIntensity = driverIntensity;
    }

    public Motorcycle(string name, int driverIntensity) : this(name)
    {
        this.driverIntensity = driverIntensity;
    }

}
