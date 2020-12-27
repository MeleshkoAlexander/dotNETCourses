using System;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Punctuation: IPunctuation,ICloneable
    {
        public Symbol Symbol { get; }

        public string Chars => Symbol.Chars;

        public Punctuation(string chars)
        {
            Symbol = new Symbol(chars);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}