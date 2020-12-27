using TextModel.Interfaces;

namespace TextModel.Model.Text
{
    public class Symbol: ISymbol
    {
        public string Chars
        {
            get => Chars;
            private set => Chars = value;
        }

        public Symbol(string chars)
        {
            this.Chars = chars;
        }

        public Symbol(char value)
        {
            Chars = string.Format($"{value}");
        }
    }
}