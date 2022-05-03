namespace Problem10
{

    using System;

    public class Program
    {

        static void Main(string[] args)
        {
            //2. Написать метод расширения для типа string.
            //Метод имеет один входной параметр типа char и вычисляет количество символов, равных этому параметру c типом char.
            string str = "strings";
            Console.WriteLine(str.FindEntriesCount('s'));


            //6. Создать частичный класс Person с методами Eat, Sleep, Run разделив их на разные классы
            Person person = new Person();
            person.Sleep();
            person.Eat();
            person.Run();


            //11. Создать экземпляр анонимного типа с помощью проекции (инициализаторы с проекцией).
            person.Name = "Vladimir";
            int Age = 18;
            var vladimir = new { person.Name, Age };


            //12. локальные функции
            void LocalFunc()
            {
                Console.WriteLine("Local");
            }


            //18. Написать примеры с использованием nullable-типов
            int? number = 1;
            number++;
            number = null;


            //20. преобразование:
            int? nullableInt = null;
            int valueInt;

            //➔	явное преобразование от T? к T
            if (nullableInt.HasValue)
            {
                valueInt = (int)nullableInt;
            }


            //➔	неявное преобразование от T к T?
            valueInt = 4;
            nullableInt = valueInt;


            //➔	неявные расширяющие преобразования от V к T?
            nullableInt = 4;
            long? nullableLong = nullableInt;


            //➔	явные сужающие преобразования от V к T?
            long valueLong = 4;
            nullableInt = (int?)valueLong;


            //➔	преобразования от V? к T?
            nullableInt = (int?)nullableLong;
            nullableLong = nullableInt;


            //➔	явные преобразования от V? к T
            if (nullableLong.HasValue)
            {
                valueInt = (int)nullableLong;
            }

        }


        //16. Написать метод GetSum. Параметры методы – массив чисел.
        //Возвращает сумму чисел больше 5. Внутри метода определить локальную функцию, проверяющую элемент массива
        static int GetSum(int[] nums)
        {
            int sum = 0;

            foreach (var num in nums)
            {
                if (NumIsValid(num))
                    sum += num;
            }

            return sum;

            bool NumIsValid(int number) => number > 5;
        }

    }

}