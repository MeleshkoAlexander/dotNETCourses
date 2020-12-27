using System.Collections;
using System.Collections.Generic;

namespace TextModel.Interfaces
{
    public interface ISentence
    {
        IList<ISentenceItem> Items { get; }
        void Add(ISentenceItem item);
        IList<ISentenceItem> GetSentenceItems();
    }
}