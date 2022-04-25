using Problem4;
using Problem4.Interfaces;
using System.Collections;

Counter acounter = new Counter() { Seconds = 3 };
int a = acounter;
int b = 30;
Counter bcounter = b;

LongCredit credit = new LongCredit();
credit.Sum = 2000000;
credit.PrintSum();

//переопределенное свойство вывело бы "Employee" в обоих случаях
Person person = new Employee();
Console.WriteLine(person.Name);
Employee employee = (Employee)person;
Console.WriteLine(employee.Name);

Square square = new Square(4);
square.InfoFigure();
Figure figure = new Triangle(3);
figure.InfoFigure();

IFigure fig = new SquareWithInterface(4);
fig.InfoFigure();


//Быстрее обычный список, потому что ArrayList пересоздает массив и копирует значения
//это занимает много времени
ArrayList al = new ArrayList();
List<int> l = new List<int>();
DateTime start = DateTime.Now;
for(int i = 1; i <= 1000000; i++)
    al.Add(i);
Console.WriteLine("ArrayList: " + (DateTime.Now - start).ToString());
start = DateTime.Now;
for (int i = 1; i <= 1000000; i++)
    l.Add(i);
Console.WriteLine("List: " + (DateTime.Now - start).ToString());

Account<string> account = new Account<string>();
Account<string>.bank = "bank";
Account<int> account1 = new Account<int>();
Console.WriteLine(Account<string>.bank);
Console.WriteLine(Account<int>.bank + "\n");

ArrayClass<int> array = new ArrayClass<int>(1);
array[0] = 5;
array.Add(1);
array.Add(2);
array.Delete(0);
for(int i = 0; i < array.Length; i++)
    Console.WriteLine(array[i]);