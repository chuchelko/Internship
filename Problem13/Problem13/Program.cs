namespace Problem13
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N: ");
            if (!int.TryParse(Console.ReadLine(), out int N))
            {
                Console.WriteLine("должно быть число");
                return;
            }

            int[] arr = new int[N];


            Console.WriteLine("Введите числа для массива: ");
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Console.WriteLine(Count(arr));
        }

        static int Count(int[] arr)
        {
            int count = 0;

            var t1 = new Thread(() =>
            {
                for(int i = 0; i < arr.Length; i+=2)
                    Interlocked.Add(ref count, arr[i]);
            });

            var t2 = new Thread(() =>
            {
                for (int i = 1; i < arr.Length; i += 2)
                    Interlocked.Add(ref count, arr[i]);
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            return count;
        }
    }
}
