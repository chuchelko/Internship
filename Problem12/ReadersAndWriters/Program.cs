namespace ReadersAndWriters
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(() =>
                {
                    for (int j = 0; j < 2000; j++)
                    {
                        if (j == 10)
                            new Thread(() => Console.WriteLine(Database.Read()[^1])).Start();
                        Database.Write("Thread " + i * j);
                    }
                }).Start();
            }


        }
    }
}
