using System.Runtime.InteropServices;
using TextModel.Interfaces;

namespace TextModel.Model.Separators
{
    public class WordSeparators: ISeparator
    {
        public string[] Separators { get; }

        public WordSeparators()
        {
            Separators= new[] { ",", "-", ";", ":", "\"" };
        }
    }
}