using System;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Text: IText,ICloneable
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}