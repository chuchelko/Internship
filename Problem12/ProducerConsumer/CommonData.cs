namespace ProducerConsumer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class CommonData
    {
        private static List<int> _info = new List<int>();
        
        private static object _newDataAddingLocker = new object();

        private static object _dataProducingLocker = new object();

        private static object _dataConsumingLocker = new object();

        public static int Produce(int data)
        {
            int index;
            try
            {
                Monitor.Enter(_dataProducingLocker);
                _info.Add(data);
                Monitor.Enter(_newDataAddingLocker);
                Monitor.Pulse(_newDataAddingLocker);
                Monitor.Exit(_newDataAddingLocker);
                index = _info.IndexOf(data);
            }
            finally
            {
                Monitor.Exit(_dataProducingLocker);
            }
            return index;
        }

        public static int Consume(int index)
        {
            int result;

            try
            {
                Monitor.Enter(_dataConsumingLocker);

                Monitor.Enter(_newDataAddingLocker);

                while(_info.Count <= index)
                {
                    Monitor.Wait(_newDataAddingLocker);
                }

                result = _info[index];
                _info.RemoveAt(index);

                Monitor.Exit(_newDataAddingLocker);
            }
            finally
            {
                Monitor.Exit(_dataConsumingLocker);
            }

            return result;
        }
    }
}
