using TextModel.Model.Text;

namespace TextModel.Interfaces
{
    public interface IPunctuation: ISentenceItem
    {
        Symbol Symbol { get; }
    }
}