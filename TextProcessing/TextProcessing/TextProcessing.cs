using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TextModel.Interfaces;
using TextModel.Model.Members;
using TextModel.Parser;

namespace TextProcessing.TextProcessing
{
    public static class TextProcessing
    {
        public delegate int SortBy(ISentence a, ISentence b);

        public static void Sort(IText text, SortBy sortBy)
        {
            (text.Sentences as List<ISentence>)?.Sort((a, b) => sortBy(a, b));
        }

        public static IEnumerable<IWord> FindInQuestion(IText text, int length)
        {
            var list = new List<IWord>();
            var isHave = false;
            foreach (var sentence in text.Sentences)
            {
                if (sentence.Items[sentence.Items.Count - 1].Chars != "?") continue;
                foreach (var item in sentence.Items)
                {
                    if (item.Chars.Length != length || !(item is Word word)) continue;
                    if (list.Any())
                    {
                        var count = list.Count;
                        for (var i = 0; i < count; i++)
                        {
                            if (list[i].Chars != item.Chars) continue;
                            isHave = true;
                            break;
                        }

                        if (!isHave) list.Add(word);
                        isHave = false;
                    }
                    else
                    {
                        list.Add(word);
                    }
                }
            }

            return list;
        }

        public static IText DeleteConsonants(IText text, int length)
        {
            var newText = text;
            var buffer = new Sentence();
            var consonants = new Dictionary<string, string>
            {
                {"B", "b"}, {"C", "c"}, {"D", "d"}, {"F", "f"}, {"G", "g"}, {"H", "h"}, {"J", "j"}, {"K", "k"},
                {"L", "l"}, {"M", "m"},
                {"N", "n"}, {"P", "p"}, {"Q", "q"}, {"R", "r"}, {"S", "s"}, {"T", "t"}, {"V", "v"}, {"W", "w"},
                {"X", "x"}, {"Y", "y"}, {"Z", "z"}
            };

            foreach (var sentence in newText.Sentences)
            {
                for (var i = 0; i < sentence.Items.Count; i++)
                {
                    if (!(sentence.Items[i] is Word)) continue;
                    if (consonants.Any(s =>
                        (sentence.Items[i].Chars.StartsWith(s.Key) || sentence.Items[i].Chars.StartsWith(s.Value))
                        && sentence.Items[i].Chars.Length == length))
                    {
                        sentence.Items.Remove(sentence.Items[i]);
                    }
                }
            }

            return newText;
        }

        public static ISentence ReplaceWordOnSubstring(ISentence sentence, int length, string subString)
        {
            var newSentence = sentence;
            var count = newSentence.Items.Count;
            for(var i=0;i<count;i++)
            {
                if (newSentence.Items[i].Chars.Length != length) continue;
                var index = newSentence.Items.IndexOf(newSentence.Items[i]);
                newSentence.Items.RemoveAt(index);
                var word = new Word(subString);
                newSentence.Items.Insert(index, word);
            }

            return newSentence;
        }
    }
}