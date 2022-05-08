namespace Problem12
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {

            Thread thread1 = new Thread(Method);
            Thread thread2 = new Thread(Method);

            thread1.Name = " th1";
            thread2.Name = " th2";

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

        }

        static int i = 0;

        static object lockerObject = new object();

        static public void Method()
        {
            using(Locker locker = new Locker(lockerObject))
            {
                for (int j = 0; j < 10; j++)
                {
                    i++;
                    Console.WriteLine(j.ToString() + " " + i.ToString() + Thread.CurrentThread.Name);
                }

            }

        }

        //static public void Method()
        //{
        //    lock(lockerObject)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            i++;
        //            Thread.Sleep(300);

        //            Console.WriteLine(j.ToString() + " " + i.ToString() + Thread.CurrentThread.Name);


        //            if (j == 2)
        //                Monitor.Pulse(lockerObject);
        //            if (j == 3 && Thread.CurrentThread.Name == " th1")
        //                Monitor.Wait(lockerObject);
        //        }

        //    }

        //}
    }
}
