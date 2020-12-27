using System.Collections;
using System.Collections.Generic;

namespace TextModel.Interfaces
{
    public interface IText
    {
        IList<ISentence> Sentences { get; }
        void Add(ISentence sentence);
        IList<ISentence> GetSentences();

    }
}