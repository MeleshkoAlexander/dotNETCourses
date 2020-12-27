using TextModel.Interfaces;

namespace TextModel.Model.Separators
{
    public class SentenceSeparators: ISeparator
    {
        public string[] Separators { get; }

        public SentenceSeparators()
        {
            Separators = new[] {".", "!", "?"};
        }
    }
}