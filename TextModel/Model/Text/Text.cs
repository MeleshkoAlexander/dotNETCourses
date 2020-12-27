using System.Collections;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Text
{
    public class Text: IText
    {
        public ICollection<ISentence> Sentences { get; }

        public Text()
        {
            Sentences = new List<ISentence>();
        }
        public void Add(ISentence sentence)
        {
            Sentences.Add(sentence);
        }

        public ICollection<ISentence> GetSentences()
        {
            return Sentences;
        }
    }
}