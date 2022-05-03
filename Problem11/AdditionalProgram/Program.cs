namespace AdditionalProgram
{
    using System;
    using System.Threading;
    class Program
    {
        static int x = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Поток " + i.ToString();
                myThread.Start();
            }

            Console.ReadLine();
        }

        public static object lockObject = new object();
        public static void Count()
        {
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                lock(lockObject)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);

                }
            }
        }
    }

}