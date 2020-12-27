using System.Runtime.InteropServices;
using TextModel.Interfaces;

namespace TextModel.Model.Separators
{
    public class WordSeparators: ISeparator
    {
        public string[] separators { get; }

        public WordSeparators()
        {
            separators= new[] { ",", "-", ";", "'", ":", "\"" };
        }
    }
}