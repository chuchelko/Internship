namespace ProducerConsumer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Producer
    {
        public void Produce(int data)
        {
            new Thread(() => Console.WriteLine($"Producer produced {data} at index {CommonData.Produce(data)}")).Start();
        }
    }
}
