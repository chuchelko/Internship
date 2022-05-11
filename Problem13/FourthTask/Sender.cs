namespace FourthTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Sender
    {
        public void Send(int x)
        {
            new Thread(() =>
            {
                Numbers.Add(x);
                Console.WriteLine("Added " + x);
            }).Start();
        }
    }
}
