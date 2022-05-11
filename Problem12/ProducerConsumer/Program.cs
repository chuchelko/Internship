namespace ProducerConsumer
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            Producer producer = new Producer();
            producer.Produce(1);
            producer.Produce(2);
            consumer.Consume(1);
            Thread.Sleep(1000);
            producer.Produce(3);
            producer.Produce(4);
            Thread.Sleep(1000);
            consumer.Consume(0);
            consumer.Consume(0);
            consumer.Consume(0);
            //consumer.Consume(0);
            //producer.Produce(5);
        }
    }
}
