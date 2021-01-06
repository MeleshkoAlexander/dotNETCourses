using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TextModel.Interfaces;
using TextModel.Model.Members;
using TextModel.Parser;

namespace TextProcessing.TextProcessing
{
    public class TextProcessing
    {
        public delegate int SortBy(ISentence a, ISentence b);

        public void Sort(IText text, SortBy sortBy)
        {
            text.Sentences.Sort(((a,b)=>sortBy(a,b)));
        }

        public IEnumerable<IWord> FindInQuestion(IText text, int length)
        {
            var words = new List<Word>();
            foreach (var item in text.Sentences
                .Where(sentence => sentence.Items[sentence.Items.Count - 1].Chars == "?")
                .SelectMany(sentence => sentence.Items))
            {
                if(item.GetType()!=typeof(Word)) continue;
                if(item.Chars.Length != length) continue;
                if(AlredyAdded(words,item)) continue;
                words.Add((Word)item);
            }

            return words;
        }

        private bool AlredyAdded(IEnumerable<ISentenceItem> words,ISentenceItem value)
        {
            return words.Any(word => word == value);
        }
        

        public IText DeleteConsonants(IText text, int length)
        {
            var consonants = new Dictionary<string, string>
            {
                {"B", "b"}, {"C", "c"}, {"D", "d"}, {"F", "f"}, {"G", "g"}, {"H", "h"}, {"J", "j"}, {"K", "k"},
                {"L", "l"}, {"M", "m"},
                {"N", "n"}, {"P", "p"}, {"Q", "q"}, {"R", "r"}, {"S", "s"}, {"T", "t"}, {"V", "v"}, {"W", "w"},
                {"X", "x"}, {"Y", "y"}, {"Z", "z"}
            };

            foreach (var sentence in text.Sentences)
            {
                for (var i = 0; i < sentence.Items.Count; i++)
                {
                    var word = sentence.Items[i];
                    if (word.GetType()!=typeof(Word)) continue;
                    if (consonants.Any(s =>
                        (word.Chars.StartsWith(s.Key) || word.Chars.StartsWith(s.Value))
                        && word.Chars.Length == length))
                    {
                        sentence.Items.Remove(word);
                    }
                }
            }

            return text;
        }

        public ISentence ReplaceWordOnSubstring(ISentence sentence, int length, string subString)
        {
            var count = sentence.Items.Count;
            for(var i=0;i<count;i++)
            {
                if (sentence.Items[i].Chars.Length != length) continue;
                var index = sentence.Items.IndexOf(sentence.Items[i]);
                sentence.Items.RemoveAt(index);
                var word = new Word(subString);
                sentence.Items.Insert(index, word);
            }

            return sentence;
        }
    }
}