using System;
using System.Collections;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Sentence: ISentence,ICloneable
    {
        public IList<ISentenceItem> Items { get; }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}