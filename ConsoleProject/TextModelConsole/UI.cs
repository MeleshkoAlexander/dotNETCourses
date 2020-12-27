using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using TextModel.Interfaces;
using TextModel.Parser;
using TextProcessing.TextProcessing;

namespace ConsoleProject.TextModelConsole
{
    public static class Ui
    {
        public static void Menu()
        {
            var console = new ProcessingConsole();
            while (true)
            {
                InputMenu();
                var choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    default: throw new Exception("This number not exist in this menu");
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    case 1:
                    {
                        console.Show();
                        break;
                    }
                    case 2:
                    {
                        console.Sort();
                        break;
                    }
                    case 3:
                    {
                        console.Find(Convert.ToInt32(IOC.OutputMessage("Length:")));
                        break;
                    }
                    case 4:
                    {
                        console.Delete(Convert.ToInt32(IOC.OutputMessage("Length")));
                        break;
                    }
                    case 5:
                    {
                        console.Replace(Convert.ToInt32(IOC.OutputMessage("Index:")),Convert.ToInt32(IOC.OutputMessage( "Length")),
                            IOC.OutputMessage("new string:"));
                        break;
                    }
                    case 6:
                    {
                        break;
                    }
                }
            }
        }

        private static void InputMenu()
        {
            IOC.InputMessage("1.Show");
            IOC.InputMessage("2.Sort by letter counts");
            IOC.InputMessage("3.Word of given length");
            IOC.InputMessage("4.Delete words");
            IOC.InputMessage("5.Changes");
            IOC.InputMessage("6.Save in file");
            IOC.InputMessage("0.Exit");
        }
    }
}