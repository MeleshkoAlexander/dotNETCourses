using System.Collections;
using TextModel.Model.Members;

namespace TextModel.Interfaces
{
    public interface IWord: ISentenceItem,IEnumerable
    {
        Symbol this[int index] { get; }
        int Length { get; }
    }
}