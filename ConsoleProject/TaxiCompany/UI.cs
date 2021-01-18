using System;
using ConsoleProject.Interfaces;

namespace ConsoleProject.TaxiCompany
{
    public static class Ui
    {
        public static void Menu()
        {
            var taxiConsole=new TaxiCompanyConsole();
            while (true)
            {
                InputMenu();
                var choose = Convert.ToInt32(IocStatic.OutputMessage(">>"));
                switch (choose)
                {
                    default:throw new Exception("This number not exist in this menu");
                    case 1:
                    {
                        taxiConsole.ShowList();
                        break;
                    }
                    case 2:
                    {
                        taxiConsole.Create();
                        break;
                    }
                    case 3:
                    {
                        taxiConsole.CompanyCost();
                        break;
                    }
                    case 4:
                    {
                        taxiConsole.Sort();
                        break;
                    }
                    case 5:
                    {
                        taxiConsole.SpeedSelection(Convert.ToDouble(IocStatic.OutputMessage("Min: ")),Convert.ToDouble(IocStatic.OutputMessage("Max: ")));
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
            IocStatic.InputMessage("1.Show");
            IocStatic.InputMessage("2.Create ");
            IocStatic.InputMessage("3.Company cost");
            IocStatic.InputMessage("4.Sort by Consumption");
            IocStatic.InputMessage("5.Find by speed");
            IocStatic.InputMessage("0. Exit");
        }
    }
}