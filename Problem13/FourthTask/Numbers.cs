namespace FourthTask
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class Numbers
    {
        private static int? _number = null;

        private static object _addingLocker = new object();

        private static object _gettingLocker = new object();

        public static void Add(int data)
        {
            try
            {
                Monitor.Enter(_addingLocker);

                if(_number.HasValue)
                    Monitor.Wait(_addingLocker);

                _number = data;
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

                if(!_number.HasValue)
                {
                    Monitor.Wait(_gettingLocker);
                }
                result = _number.Value;
                _number = null;
                Monitor.Enter(_addingLocker);
                Monitor.Pulse(_addingLocker);
                Monitor.Exit(_addingLocker);
            }
            finally
            {
                Monitor.Exit(_gettingLocker);
            }

            return result;
        }

    }
}
