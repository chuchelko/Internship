namespace FourthTask
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Reciever reciever = new Reciever();
            Sender sender = new Sender();
            
            for (int i = 1; i < 51; i++)
                reciever.Recieve();

            for (int i = 1; i < 51; i++)
                sender.Send(i);
        }
    }
}
