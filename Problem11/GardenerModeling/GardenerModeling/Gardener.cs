namespace GardenerModeling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public enum GardenerType
    {
        UpperLeft,
        BottomRight
    }

    internal class Gardener
    {

        private Garden _garden;

        private double _cellsPerSecond = 1;

        private GardenerType _type;

        private object _locker = new object();

        private int x, y;

        public Gardener(double cellsPerSecond, GardenerType type, Garden garden)
        {
            _garden = garden;
            _cellsPerSecond = cellsPerSecond;
            _type = type;

            if (type == GardenerType.BottomRight)
            {
                x = _garden.Width - 1;
                y = _garden.Height - 1;
            }
        }

        public void Start()
        {
            Thread thread = new Thread(StartGardening);
            thread.Start();
        }

        private void StartGardening()
        {

            if (_type == GardenerType.UpperLeft)
                _garden.Paint(x, y, '#');
            else
                _garden.Paint(x, y, '$');

            Thread.Sleep((int)(1000 / _cellsPerSecond));

            while (true)
            {

                lock (_locker)
                {
                    if (_garden.CellsLeft == 0)
                        break;

                    if (_type == GardenerType.BottomRight)
                    {
                        y -= 1;

                        if (y < 0 || _garden.IsPainted(x, y))
                        {
                            y = _garden.Height - 1;
                            x -= 1;
                        }
                        _garden.Paint(x, y, '$');
                    }
                    else if (_type == GardenerType.UpperLeft)
                    {
                        x += 1;

                        if (x == _garden.Width || _garden.IsPainted(x, y))
                        {
                            x = 0;
                            y += 1;
                        }
                        _garden.Paint(x, y, '#');
                    }
                    _garden.Print();
                    Thread.Sleep((int)(1000 / _cellsPerSecond));
                }
            }
        }

    }
}
