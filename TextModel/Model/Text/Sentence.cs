using System.Collections;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Text
{
    public class Sentence: ISentence
    {
        public ICollection<ISentenceItem> Items { get; }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }
        public void Add(ISentenceItem item)
        {
            Items.Add(item);
        }

        public ICollection<ISentenceItem> GetSentenceItems()
        {
            return Items;
        }
    }
}