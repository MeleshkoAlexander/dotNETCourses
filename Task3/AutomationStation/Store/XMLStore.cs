using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AutomationStation.Store
{
    public class XMLStore : IStore
    {

        public void LoadCollection<T>(List<T> collection,string path)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, collection);
                fs.Close();
            }
        }

        public void SaveCollection<T>(List<T> collection,string path)
        {
            var serializer = new XmlSerializer(typeof(T[]));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var objects = (T[]) serializer.Deserialize(fs);
                collection.AddRange(objects);
                fs.Close();
            }
        }
    }
}