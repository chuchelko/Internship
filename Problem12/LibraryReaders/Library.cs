namespace LibraryReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Library
    {
        private Semaphore _semaphore = new Semaphore(3, 3);

        private Queue<Reader> _readers;

        public Library(Queue<Reader> readers)
        {
            _readers = readers;
        }

        public void StartWorking()
        {
            while(_readers.TryDequeue(out Reader reader))
            {
                _semaphore.WaitOne();
                Thread thread = new Thread(() =>
                {
                    reader.Read();

                    if (!reader.CompletedReading)
                        _readers.Enqueue(reader);

                    _semaphore.Release();
                });

                thread.Start();


            }

        }

    }
}
