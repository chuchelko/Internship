namespace Problem4;

internal class Person
{
    public string Name => "Person";
}

internal class Employee : Person
{
    public new string Name => "Employee";
}
