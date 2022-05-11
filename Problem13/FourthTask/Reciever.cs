namespace FourthTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Reciever
    {
        public void Recieve()
        {
            new Thread(() =>
            {
                Console.WriteLine("Recieved " + Numbers.Recieve());
            }).Start();
        }
    }
}
