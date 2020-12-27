using TextModel.Model.Members;

namespace TextModel.Interfaces
{
    public interface IPunctuation: ISentenceItem
    {
        Symbol Symbol { get; }
    }
}