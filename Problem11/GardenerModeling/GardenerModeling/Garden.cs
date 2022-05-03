namespace GardenerModeling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Garden
    {

        private readonly char[,] _map;

        public readonly int Width, Height;

        public int CellsLeft { get; private set; }

        public Garden(int width, int height)
        {
            Width = width;
            Height = height;
            CellsLeft = width * height;
            _map = new char[height, width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    _map[i, j] = ' ';
        }

        public void Print()
        {
            Console.Clear();
            for(int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write(_map[i, j]);

                Console.WriteLine();
            }
        }

        public bool IsPainted(int x, int y) => _map[y, x] != ' ';

        public void Paint(int x, int y, char c)
        {
            CellsLeft -= 1;
            if(CellsLeft > -1)
                _map[y, x] = c;
        }
    }
}
