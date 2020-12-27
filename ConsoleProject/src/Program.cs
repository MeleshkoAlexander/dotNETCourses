using System;
using ConsoleProject.TextModelConsole;

namespace ConsoleProject
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Ui.Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}