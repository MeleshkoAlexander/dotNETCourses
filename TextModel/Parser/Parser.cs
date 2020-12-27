using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Net.Mime;
using TextModel.Interfaces;
using TextModel.Model.Members;
using TextModel.Model.Separators;

namespace TextModel.Parser
{
    public class Parser
    {
        private readonly Text _text = new Text();
        private readonly IFileService _fileService = new FileService.FileService();
        private readonly ISeparator _wordSeparator = new WordSeparators();
        private readonly ISeparator _sentenceSeparator = new SentenceSeparators();

        public void Parse(string path)
        {
            var buffer = "";
            var sentence = new Sentence();
            using (var streamReader = _fileService.GetStreamReader(path))
            {
                while (streamReader.Peek() > 0)
                {
                    var symbol = (char) streamReader.Read();
                    if (symbol == '\n') symbol = (char) streamReader.Read();
                    if (symbol != ' ' && symbol != '\t')
                    {
                        var isAdded = IsWordSeparator(buffer, sentence, symbol.ToString());
                        if (!isAdded) isAdded = IsSentenceSeparator(buffer, ref sentence, symbol.ToString(), streamReader);
                        if (!isAdded) buffer += symbol;
                        else buffer = "";
                    }
                    else
                    {
                        if (symbol == '\t')
                        {
                            NewWord(buffer, sentence);
                            buffer = "";
                        }
                        else
                        {
                            NewWord(buffer, sentence);
                            while (streamReader.Peek() == ' ')
                            {
                                streamReader.Read();
                            }

                            buffer = "";
                        }
                    }
                }
            }
        }

        private bool IsSentenceSeparator(string buffer,ref Sentence sentence, string symbol, TextReader streamReader)
        {
            foreach (var sentenceSeparator in _sentenceSeparator.Separators)
            {
                if (sentenceSeparator != symbol.ToString()) continue;
                if (streamReader.Peek() == '!' || streamReader.Peek() == '?')
                {
                    var newBuffer = symbol.ToString() + streamReader.Read().ToString();
                    NewPunctuation(newBuffer, sentence);
                    return true;
                }
                else if (streamReader.Peek() == '.')
                {
                    var newBuffer = symbol.ToString() + streamReader.Read().ToString() +
                                    streamReader.Read().ToString();
                    NewPunctuation(newBuffer, sentence);
                    return true;
                }
                else
                {
                    NewWord(buffer, sentence);
                    NewPunctuation(symbol.ToString(), sentence);
                    _text.Sentences.Add(sentence);
                    sentence = new Sentence();
                    if (streamReader.Peek() > 0 && streamReader.Peek() == ' ') streamReader.Read();
                    return true;
                }
            }

            return false;
        }

        private bool IsWordSeparator(string buffer, ISentence sentence, string symbol)
        {
            if (_wordSeparator.Separators.All(wordSeparator => wordSeparator != symbol)) return false;
            NewWord(buffer, sentence);
            NewPunctuation(symbol, sentence);
            return true;
        }


        private static void NewWord(string buffer, ISentence sentence)
        {
            var word = new Word(buffer);
            sentence.Items.Add(word);
        }

        private static void NewPunctuation(string symbol, ISentence sentence)
        {
            var punctuation = new Punctuation(symbol.ToString());
            sentence.Items.Add(punctuation);
        }

        public Text GetTextCopy()
        {
            return (Text) _text.CloneText();
        }
    }
}