namespace GardenerModeling
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Garden garden = new Garden(4, 5);
            Gardener leftGardener = new Gardener(2, GardenerType.UpperLeft, garden);
            Gardener rightGardener = new Gardener(3, GardenerType.BottomRight, garden);

            leftGardener.Start();
            rightGardener.Start();

        }
    }

}
