namespace SecondTask
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

            Console.WriteLine("Введите к: ");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("должно быть число");
                return;
            }

            int[] arr = new int[N];

            Console.WriteLine("Введите числа для массива: ");
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Console.WriteLine(Count(arr, k));
        }

        public static int Count(int[] arr, int k)
        {
            int count = 0;

            for(int i = 0; i < k; ++i)
            {
                Thread thread = new Thread(() =>
                {
                    for (int j = i; j < arr.Length; j += k)
                        Interlocked.Add(ref count, arr[j]);
                });
                thread.Start();
                thread.Join();
            }

            return count;
                
        }
    }
}
