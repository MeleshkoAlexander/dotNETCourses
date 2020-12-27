using TextModel.Interfaces;

namespace TextModel.Model.Separators
{
    public class LargeSentenceSeparators : ISeparator
    {
        public string[] separators { get; }

        public LargeSentenceSeparators()
        {
            separators = new[] {"...", "?!", "!?"};
        }
    }
}