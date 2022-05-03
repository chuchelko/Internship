namespace Problem9
{

    using System;

    internal class Program
    {

        delegate double Method(double d);

        delegate void MessageHandler(string message);

        static void Main(string[] args)
        {
            Method method = GetCircumference;

            MessageHandler messageHandler = (string message) => Console.WriteLine(message);

            ShowMessage("Message", (string message) => Console.WriteLine(message));
        }

        static double GetCircumference(double R) => 2 * Math.PI * R;

        static double GetCircleArea(double R) => Math.PI * R * R;

        static double GetSphereVolume(double R) => 4/3 * Math.PI * R * R * R;

        static void ShowMessage(string mes, MessageHandler handler) => handler(mes);

    }

}