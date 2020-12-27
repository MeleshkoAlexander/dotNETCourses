using System.CodeDom.Compiler;
using System.Linq;
using System.Net.Mime;
using TextModel.Interfaces;
using TextModel.Model.Members;
using TextModel.Model.Separators;

namespace TextModel.Parser
{
    public class Parser
    {
        private readonly IText _text = new Text();
        private readonly IFileService _fileService = new FileService.FileService();
        private readonly ISeparator _wordSeparator = new WordSeparators();
        private readonly ISeparator _sentenceSeparator = new SentenceSeparators();

        public void Parse(string path)
        {
            var buffer = "";
            var sentence = new Sentence();
            bool isAdded = false;
            using (var streamReader = _fileService.GetStreamReader(path))
            {
                while (streamReader.Peek() > 0)
                {
                    var symbol = (char) streamReader.Read();
                    isAdded = false;
                    if (symbol == '\n') symbol = (char) streamReader.Read();
                    if (symbol != ' ' && symbol != '\t')
                    {
                        foreach (var wordSeparator in _wordSeparator.separators)
                        {
                            if (wordSeparator != symbol.ToString()) continue;
                            NewWord(buffer, sentence);
                            NewPunctuation(symbol.ToString(), sentence);
                            buffer = "";
                            isAdded = true;
                            break;
                        }

                        foreach (var sentenceSeparator in _sentenceSeparator.separators)
                        {
                            if (sentenceSeparator == symbol.ToString())
                            {
                                if (streamReader.Peek() == '!' || streamReader.Peek() == '?')
                                {
                                    var newBuffer = symbol.ToString() + streamReader.Read().ToString();
                                    NewPunctuation(newBuffer, sentence);
                                    break;
                                }
                                else if (streamReader.Peek() == '.')
                                {
                                    var newBuffer = symbol.ToString() + streamReader.Read().ToString() +
                                                    streamReader.Read().ToString();
                                    NewPunctuation(newBuffer, sentence);
                                    break;
                                }
                                else
                                {
                                    NewWord(buffer, sentence);
                                    NewPunctuation(symbol.ToString(), sentence);
                                    _text.Add(sentence);
                                    sentence = new Sentence();
                                    if (streamReader.Peek() > 0&& streamReader.Peek()==' ') streamReader.Read();
                                    buffer = "";
                                    isAdded = true;
                                    break;
                                }
                            }
                        }

                        if (!isAdded) buffer += symbol;
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

        private static void NewWord(string buffer, ISentence sentence)
        {
            var word = new Word(buffer);
            sentence.Add(word);
        }

        private static void NewPunctuation(string symbol, ISentence sentence)
        {
            var punctuation = new Punctuation(symbol.ToString());
            sentence.Add(punctuation);
        }

        public IText GetTextCopy()
        {
            return (Text) (_text as Text)?.Clone();
        }

        public void SaveAsTxt(string path)
        {
            _fileService.Save(_text, path);
        }
    }
}