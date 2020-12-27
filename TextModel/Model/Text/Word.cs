using System.Collections;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using TextModel.Interfaces;

namespace TextModel.Model.Text
{
    public class Word: IWord
    {
        private readonly Symbol[] _symbols;

        public string Chars
        {
            get
            {
                var builder = new StringBuilder();
                foreach (var symbol in _symbols)
                {
                    builder.Append(symbol.Chars);
                }

                return builder.ToString();
            }
        }

        public Word(string chars)
        {
           _symbols = chars.Select(x => new Symbol(x)).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return _symbols.GetEnumerator();
        }

        public Symbol this[int index] => _symbols[index];

        public int length => _symbols.Length;
    }
}