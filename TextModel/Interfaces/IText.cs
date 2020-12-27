using System.Collections;
using System.Collections.Generic;

namespace TextModel.Interfaces
{
    public interface IText
    {
        ICollection<ISentence> Sentences { get; }
        void Add(ISentence sentence);
        ICollection<ISentence> GetSentences();

    }
}