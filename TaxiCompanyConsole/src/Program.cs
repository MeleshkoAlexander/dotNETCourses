

using System;
using TaxiCompanyConsole.UI;

namespace TaxiCompanyConsole
{
    internal class Program
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