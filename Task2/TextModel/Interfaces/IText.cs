using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TextModel.Interfaces
{
    public interface IText
    {
        List<ISentence> Sentences { get; }
    }
}