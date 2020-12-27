using TextModel.Interfaces;

namespace TextModel.Model.Separators
{
    public class SentenceSeparators: ISeparator
    {
        public string[] separators { get; }

        public SentenceSeparators()
        {
            separators = new[] {".", "!", "?"};
        }
    }
}