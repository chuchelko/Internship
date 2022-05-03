namespace Problem8
{
    using System;
    

    static class Program
    {

        delegate void Message();

        delegate void SomeDel(int a, double b);

        delegate int WillReturnIntegerDelegate(int a);

        public delegate void LoggerDelegate(int a);

        public delegate T GenericFunctionDelegate<T, K1, K2>(K1 firstArgument, K2 secondArgument);

        public static void Main()
        {
            //1. Прочитать про делегаты, ключевое слово delegate.
            //Объявить делегат Message возвращаемый тип void без параметров. Создать переменную делегата,
            //создать подходящий метод, присвоить соответствующий адрес метода и вызвать метод
            Message message = WriteMessageOnConsole;
            message();

            void WriteMessageOnConsole() => Console.WriteLine("message");


            //2. Посмотреть различные способы присвоения ссылки на метод
            //создание делегата через конструктор:
            message = new Message(WriteMessageOnConsole);


            //3.Объявить делегат delegate void SomeDel(int a, double b). Посмотреть, какие из след. методов соответствуют делегату:
            //void SomeMethod1(int g, double n) { }             да
            //int SomeMethod2(int g, double n) { }              нет, возвращаемые типы разные
            //void SomeMethod3(double n, int g) { }             нет, типы аргументов разные
            //void SomeMethod4(ref int g, double n) { }         нет, ref в первом аргументе 
            //void SomeMethod5(out int g, double n) { g = 6; }  нет, out в первом аргументе


            //4. Добавить в делегат SomeDel несколько методов и вызвать делегат.
            SomeDel someDel = null;

            someDel += delegate (int a, double b)
            {
                Console.WriteLine(a + b);
            };

            someDel += delegate (int a, double b)
            {
                Console.WriteLine(a * b);
            };

            //someDel(1, 2);


            //5. Понять, как объединять несколько делегатов. Написать примеры.
            SomeDel someDel1 = delegate (int a, double b)
            {
                Console.WriteLine(a / 2);
            };

            SomeDel union = someDel + someDel1;
            union(6, 2);


            //6. Посмотреть способы вызова делегатов. Изучить метод Invoke(). Написать примеры
            WillReturnIntegerDelegate nullDel = null;
            Console.WriteLine("6. " + nullDel?.Invoke(1));


            nullDel += delegate (int x)
            {
                return x > 0 ? 1 : 0;
            };

            Console.WriteLine("6. " + nullDel?.Invoke(1));


            //7. Написать методы, принимающие делегат как параметр
            LoggerDelegate @delegate = delegate(int x) { Console.WriteLine("Logger Delegate " + x); };
            GetValue(1, @delegate);
            GetValue(1);


            //8. Посмотреть как определяются обобщенные делегаты. Написать примеры.

            GenericFunctionDelegate<float, int, int> genericFunctionDelegate = 
                delegate (int a, int b) 
                {
                    return a / b; 
                };
            Console.WriteLine(genericFunctionDelegate(6, 3));

        }

        public static int GetValue(int x, LoggerDelegate loggerDelegate = null)
        {
            int y = x * 3 + x * x + 2;
            loggerDelegate?.Invoke(y);
            return y;
        }

    }
    
}