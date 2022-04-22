/* 
1. константа К не инициализирована
2. значение константы после инициализации менять нельзя
3. константа становится статической переменной
7. a ?? b возвращает а, если а не null, b в противном случае. 
со значимыми типами применять можно, если они могут принимать null
9. _name не наследуется, потому что помечен private. есть доступ к Name
 */
int? a = null;
Console.WriteLine(a ?? 3);


//8
User user = new User();
Console.WriteLine(user?.Phone?.Company?.Name ?? "null");

//12
Employee employee = new Employee("name", "company");
Person person = (Person)employee;

//13
person = new Employee("name", "company");
employee = (Employee)person;

//14
(person as Employee)!.Company = "company";
(employee as Person)!.Name = "name";

class User
{
    public Phone Phone { get; set; }
}
class Phone
{
    public Company Company { get; set; }
}
class Company
{
    public string Name { get; set; }
}


//11
class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Display()
    {
        Console.WriteLine($"Person {Name}");
    }
}

class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
    : base(name)
    {
        Company = company;
    }
}

class Client : Person
{
    public string Bank { get; set; }
    public Client(string name, string bank) : base(name)
    {
        Bank = bank;
    }
}
