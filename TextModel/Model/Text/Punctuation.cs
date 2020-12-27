using TextModel.Interfaces;

namespace TextModel.Model.Text
{
    public class Punctuation: IPunctuation
    {
        public Symbol Symbol { get; }

        public string Chars => Symbol.Chars;

        public Punctuation(string chars)
        {
            Symbol = new Symbol(chars);
        }
    }
}