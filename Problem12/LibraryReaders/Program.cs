namespace LibraryReaders
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {

        static void Main(string[] args)
        {
            Queue<Reader> queue = new Queue<Reader>();
            queue.Enqueue(new Reader());
            queue.Enqueue(new Reader());
            queue.Enqueue(new Reader());
            queue.Enqueue(new Reader());
            queue.Enqueue(new Reader());

            Library library = new Library(queue);

            library.StartWorking();

        }
    }
}
