namespace ProducerConsumer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Consumer
    {
        public void Consume(int index)
        {
            new Thread(() => Console.WriteLine("Consumer consumed " + CommonData.Consume(index))).Start();
        }
    }
}
