using System;

namespace ConsoleProject
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MainMenu.ChooseTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}