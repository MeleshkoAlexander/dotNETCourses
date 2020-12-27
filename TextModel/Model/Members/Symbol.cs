using System;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Symbol: ISymbol, ICloneable
    {
        public string Chars { get; }

        public Symbol(string chars)
        {
            Chars = chars;
        }

        public Symbol(char value)
        {
            Chars = string.Format($"{value}");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}