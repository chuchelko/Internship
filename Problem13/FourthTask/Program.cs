namespace FourthTask
{
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            Reciever reciever = new Reciever();
            Sender sender = new Sender();
            
            for (int i = 1; i < 51; i++)
                reciever.Recieve();

            for (int i = 1; i < 51; i++)
            {
                sender.Send(i);
                Thread.Sleep(50);
            }
        }
    }
}
