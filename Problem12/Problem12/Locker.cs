namespace Problem12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Locker : IDisposable
    {
        private object _locker;

        public Locker(object locker)
        {
            _locker = locker;
            Monitor.Enter(_locker);
        }

        public void Dispose() => Monitor.Exit(_locker);
    }
}
