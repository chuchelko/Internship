namespace ReadersAndWriters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class Database
    {

        private static List<string> _info = new List<string>();

        private static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        public static void Write(string info)
        {
            try
            {
                _rwLock.EnterWriteLock();
                _info.Add(info);
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        public static string[] Read()
        {
            string[] result;
            try
            {
                _rwLock.EnterReadLock();
                result = _info.ToArray();
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
            return result;
        }
    }
}
