using System.IO;

namespace TextModel.Interfaces
{
    public interface IFileService
    {
        StreamReader GetStreamReader(string openPath);
        void Save(IText text,string closePath);
    }
}