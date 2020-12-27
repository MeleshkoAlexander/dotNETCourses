using System.Collections;
using System.Collections.Generic;

namespace TextModel.Interfaces
{
    public interface ISentence
    {
        ICollection<ISentenceItem> Items { get; }
        void Add(ISentenceItem item);
        ICollection<ISentenceItem> GetSentenceItems();
    }
}