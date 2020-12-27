using System;
using ConsoleProject.TextProcessing;

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