namespace Library.Fourth;

public struct State
{
    public string name;
    public Country country;
    public State(string name, Country country)
    {
        this.name = name;
        this.country = country;
    }
}
