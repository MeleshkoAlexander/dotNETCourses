using System.Collections.Generic;
using TextModel.Interfaces;
using TextModel.Parser;

namespace TextProcessing.TextProcessing
{
    public static class TextProcessing
    {
        public delegate int SortBy(ISentence a, ISentence b);

        public static void Sort(IText text,SortBy sortBy)
        {
            (text.Sentences as List<ISentence>)?.Sort((a,b)=>sortBy(a,b));
        }
    }
}