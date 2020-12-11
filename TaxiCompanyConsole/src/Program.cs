

using System;
using TaxiCompanyConsole.UI;

namespace TaxiCompanyConsole
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