using System.Linq;
using TextModel.FileService;
using TextModel.Interfaces;
using TextModel.Parser;

namespace ConsoleProject.TextModelConsole
{
    public class ProcessingConsole
    {
        private IText _text;
        private const string OpenPath = "../../../TextRead.txt";
        private const string ClosePath = "../../../TextResult.txt";
        private readonly TextProcessing.TextProcessing.TextProcessing _textWorke;

        public ProcessingConsole()
        {
            _textWorke = new TextProcessing.TextProcessing.TextProcessing();
            var parser = new Parser();
            parser.Parse(OpenPath);
            _text = parser.GetTextCopy();
        }
        public void Show()
        {
            var writing = "";
            foreach (var sentence in _text.Sentences)
            {
                foreach (var sentenceItem in sentence.Items)
                {
                    writing += sentenceItem.Chars;
                    writing += " ";
                }

                writing += '\n';
            }
            IocStatic.InputMessage(writing);
        }

        public void Sort()
        {
            _textWorke.Sort(_text,(a,b)=>a.Items.Count.CompareTo(b.Items.Count));
        }

        public void Find(int length)
        {
            var list=_textWorke.FindInQuestion(_text,length);
            var enumerable = list.ToList();
            if (!enumerable.Any())
            {
                IocStatic.InputMessage("words of this lenght not exist");
                return;
            }
            foreach (var word in enumerable)
            {
                IocStatic.InputMessage(word.Chars);
            }
        }

        public void Delete(int length)
        {
            _text=_textWorke.DeleteConsonants(_text,length);
        }

        public void Replace(int index, int length, string subString)
        {
           _text.Sentences[index] = _textWorke.ReplaceWordOnSubstring(_text.Sentences[index], length, subString);
        }

        public void Save()
        {
            var fileService = new FileService();
            fileService.Save(_text,ClosePath);
        }
    }
}