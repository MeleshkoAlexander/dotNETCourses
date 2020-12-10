using System;

namespace TaxiCompanyConsole.UI
{
    public class Ui
    {
        public static void Menu()
        {
            var taxiConsole=new TaxiCompanyConsole();
            while (true)
            {
                InputMenu();
                var choose = Convert.ToInt32(OutputMessage(">>"));
                switch (choose)
                {
                    default:throw new Exception("This number not exist in this menu");
                    case 1:
                    {
                        taxiConsole.Show();
                        break;
                    }
                    case 2:
                    {
                        taxiConsole.Create();
                        break;
                    }
                    case 3:
                    case 4:
                    {
                        taxiConsole.Sort();
                        break;
                    }
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
            
        }

        private static void InputMenu()
        {
            InputMessage("1.Show");
            InputMessage("2.Create ");
            InputMessage("3.Company cost");
            InputMessage("4.Sort by Consumption");
            InputMessage("5.Find by speed");
            InputMessage("0. Exit");
        }
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