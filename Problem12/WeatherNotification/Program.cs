namespace WeatherNotification
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(NotifyUser, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            Console.Read();
        }

        public static void NotifyUser(object obj)
        {
            Random random = new Random();
            Console.WriteLine("За окном " + random.Next(-30, 30));
        }
    }
}
