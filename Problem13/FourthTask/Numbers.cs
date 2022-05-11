namespace FourthTask
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Numbers
    {
        private static Queue<int> _info = new Queue<int>();

        private static object _addingLocker = new object();

        private static object _gettingLocker = new object();

        public static void Add(int data)
        {
            try
            {
                Monitor.Enter(_addingLocker);
                _info.Enqueue(data);
                Monitor.Enter(_gettingLocker);
                Monitor.Pulse(_gettingLocker);
                Monitor.Exit(_gettingLocker);
            }
            finally
            {
                Monitor.Exit(_addingLocker);
            }
        }

        public static int Recieve()
        {
            int result;

            try
            {
                Monitor.Enter(_gettingLocker);

                while (!_info.TryDequeue(out result))
                    Monitor.Wait(_gettingLocker);
            }
            finally
            {
                Monitor.Exit(_gettingLocker);
            }

            return result;
        }

    }
}
