using System;
using System.Collections.Generic;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Store;
using ConsoleProject.TaxiCompany;

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