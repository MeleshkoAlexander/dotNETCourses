using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TaxiCompany.Auto;

namespace TaxiCompany.Store
{
    public class XmlStore : IStore
    {
        private string path = "../../../Auto.xml";
        public void Save<TAutoType>(List<TAutoType> autoList) where TAutoType : IAuto
        {
            var serializer = new XmlSerializer(typeof(List<TAutoType>));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, autoList);
                fs.Close();
            }
        }

        public void Load<TAutoType>(List<TAutoType> autoList) where TAutoType : IAuto
        {
            var serializer = new XmlSerializer(typeof(TAutoType[]));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var autos = (TAutoType[]) serializer.Deserialize(fs);
                autoList.AddRange(autos);
                fs.Close();
            }
        }
    }
}