using System.Collections;
using System.Collections.Generic;

namespace AutomationStation.Store
{
    public interface IStore
    {
        void LoadCollection<T>(List<T> collection,string path);
        void SaveCollection<T>(List<T> collection,string path);
    }
}