namespace ThirdTask
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            new Thread(() => Console.WriteLine(Sum(arr))).Start();
            new Thread(() => Console.WriteLine(Sum(arr))).Start();
        }

        private static int Sum(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                count++;
            return count;
        }
    }
}
