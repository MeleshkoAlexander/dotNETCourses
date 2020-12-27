using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using TextModel.Interfaces;
using TextModel.Model.Members;
using TextModel.Parser;

namespace ConsoleProject.TextProcessing
{
    public static class Ui
    {
        public static void Menu()
        {
            var parser = new Parser();
            parser.Parse("../../../TextRead.txt");
            var text = parser.GetTextCopy();
            foreach (var sentence in text.Sentences)
            {
                foreach (var item in sentence.Items)
                {
                    Console.WriteLine(item.Chars);
                }
            }
        }
    }
}