using Library.First;
using Library.Third;
using Library.Fourth;

//Car car1 = new Car(100);
//Car car2 = new Car("Волга");
//Car car3 = new Car("Bmw", 150);
//car1.Print();
InheritedCar car = new InheritedCar("inherited", 20);
car.Print();
//без параметров даст эксепшн

User user = new User(); //поля обнуляются в пустом конструкторе
User user2 = new User("имя", 2);

State state = new State();
state.name = "Washington";
state.country = new Country();
state.country.name = "USA";
//State в стеке, в State указатель на Country, сам объект Country на куче 

State state1 = new State("state1", new Country { name = "country1"});
State state2 = new State("state2", new Country { name = "country2"});
state1 = state2;
state2.country.name = "changed";
Console.WriteLine(state2.country.name);
Console.WriteLine(state1.country.name);
//совпадают, потому что мы меняли поле класса, и обе структуры содержат
//указатели на один и тот же класс

//с Person отличий не будет, потому что ref действует на значимые типы