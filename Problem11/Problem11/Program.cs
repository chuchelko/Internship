
namespace Problem11
{

    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            //2.
            Console.WriteLine(@$"Имя потока: {Thread.CurrentThread.Name}
Запущен ли поток: {Thread.CurrentThread.IsAlive}
Приоритет потока: {Thread.CurrentThread.Priority}
Статус потока: {Thread.CurrentThread.ThreadState}
Домен приложения: {Thread.GetDomain()}");


            //3.Создать поток. Посмотреть статусы до запуска потока, после запуска потока, после остановки потока.
            Thread thread = new Thread(MethodForThread);
            Console.WriteLine("Main " +thread.ThreadState);
            thread.Start();
            Console.WriteLine("Main " + thread.ThreadState);


            //4. по умолчанию поток имеет приоритет Normal

            //5. Создать поток, изменить его приоритетность на Highest. Запустить поток и вывести информацию о приоритете.
            Thread threadWithHighestPriority = new Thread(() =>
            {
                    Console.WriteLine("highest priority");
            });
            threadWithHighestPriority.Priority = ThreadPriority.Highest;
            threadWithHighestPriority.Start();


            //7. Создать метод Count без параметров, который в цикле от 1 до 9 выводит в консоль «Второй поток», квадрат этих чисел и останавливает поток на 400 мс.
            //Далее в методе Main с помощью делегата ThreadStart создать новый поток, передав ему метод Count. Запустить поток.
            //После этого написать в методе Main цикл от 1 до 9 выводит в консоль «Главный поток», квадрат этих чисел и останавливает поток на 300 мс
            Thread threadCount = new Thread(new ThreadStart(Count));
            threadCount.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Главный поток " + i * i);
                Thread.Sleep(300);
            }

            threadCount.Join();

            //9. С какими ограничениями сталкиваемся при использовании ParameterizedThreadStart?
            //внутрь делегата мы можем передать объект класса object?, то есть нужно производить операции
            //упаковки и распаковки, к тому же этот объект единственный, значит нужно либо передавать объект класса/структуру
            //либо вызывать метод из объекта класса, в котором имеются уже все необходимые параметры


            //10.Переделать метод Count так, чтобы он принимал параметры.
            //Далее воспроизвести все, что было написано в пункте 7 с использованием ParameterizedThreadStart.
            //см. метод Count1
            Thread threadCount1 = new Thread(new ParameterizedThreadStart(Count1));
            threadCount1.Start(10);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Главный поток " + i * i);
                Thread.Sleep(300);
            }

            threadCount1.Join();


            //11.Запустить код (у меня это в проекте AdditionalProgram, если убрать лок из 12 пункта) и посмотреть что произойдет
            //произошел бардак - переменная x делится между потоками, она общая для всех

            //12. Изучить lock. В выше указанном примере сделать синхронизацию потоков.
        }

        static void MethodForThread() => Console.WriteLine(Thread.CurrentThread.ThreadState);

        static void Count()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Второй поток " + i * i);
                Thread.Sleep(400);
            }
        }

        static void Count1(object? intArg)
        {
            if (intArg is int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Второй поток " + i * i);
                    Thread.Sleep(400);
                }
            }
        }

    }

}