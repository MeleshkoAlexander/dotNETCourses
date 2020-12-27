using System;
using System.Collections;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Sentence: ISentence,IDisposable,ICloneable
    {
        public IList<ISentenceItem> Items { get; }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }
        public void Add(ISentenceItem item)
        {
            Items.Add(item);
        }

        public void Dispose()
        {
            Items.Clear();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}