using System.Collections;
using TextModel.Model.Text;

namespace TextModel.Interfaces
{
    public interface IWord: ISentenceItem,IEnumerable
    {
        Symbol this[int index] { get; }
        int length { get; }
    }
}