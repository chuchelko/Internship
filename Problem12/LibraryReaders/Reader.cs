namespace LibraryReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Reader
    {
        private static int _count = 0;

        private int _number;

        private int _readTimesLeft = 3;

        public bool CompletedReading => _readTimesLeft == 0;

        public Reader()
        {
            _number = ++_count;
        }

        public void Read()
        {
            _readTimesLeft--;
            Console.WriteLine($"{this} начал читать в библиотеке, осталось {_readTimesLeft} раз");
            Thread.Sleep(500);
            Console.WriteLine($"{this} закончил читать в библиотеке, осталось {_readTimesLeft} раз");
        }

        public override string ToString() => "Читатель " + _number;
    }
}
