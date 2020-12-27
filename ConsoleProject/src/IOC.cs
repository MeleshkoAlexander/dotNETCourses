using System;

namespace ConsoleProject
{
    public class IOC
    {
        public static void InputMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        public static string OutputMessage(string mes = null)
        {
            Console.WriteLine(mes);
            return Console.ReadLine();
        }
    }
}