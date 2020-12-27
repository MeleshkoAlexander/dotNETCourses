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

        public ProcessingConsole()
        {
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
            IOC.InputMessage(writing);
        }

        public void Sort()
        {
            TextProcessing.TextProcessing.TextProcessing.Sort(_text,(a,b)=>a.Items.Count.CompareTo(b.Items.Count));
        }

        public void Find(int length)
        {
            var list=TextProcessing.TextProcessing.TextProcessing.FindInQuestion(_text,length);
            var enumerable = list.ToList();
            if (!enumerable.Any())
            {
                IOC.InputMessage("words of this lenght not exist");
                return;
            }
            foreach (var word in enumerable)
            {
                IOC.InputMessage(word.Chars);
            }
        }

        public void Delete(int length)
        {
            _text=TextProcessing.TextProcessing.TextProcessing.DeleteConsonants(_text,length);
        }

        public void Replace(int index, int length, string subString)
        {
           _text.Sentences[index] = TextProcessing.TextProcessing.TextProcessing.ReplaceWordOnSubstring(_text.Sentences[index], length, subString);
        }

        public void Save()
        {
            var fileService = new FileService();
            fileService.Save(_text,ClosePath);
        }
    }
}