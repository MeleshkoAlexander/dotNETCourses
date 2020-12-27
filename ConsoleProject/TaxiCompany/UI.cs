using System;

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
                var choose = Convert.ToInt32(IOC.OutputMessage(">>"));
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
                        taxiConsole.SpeedSelection(Convert.ToDouble(IOC.OutputMessage("Min: ")),Convert.ToDouble(IOC.OutputMessage("Max: ")));
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
            IOC.InputMessage("1.Show");
            IOC.InputMessage("2.Create ");
            IOC.InputMessage("3.Company cost");
            IOC.InputMessage("4.Sort by Consumption");
            IOC.InputMessage("5.Find by speed");
            IOC.InputMessage("0. Exit");
        }
    }
}