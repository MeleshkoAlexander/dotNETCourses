using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TaxiCompany.Auto;

namespace TaxiCompany.Store
{
    public class XmlStore: IStore
    {
        public void Save(List<IAuto> autoList)
        {
            var serializer= new XmlSerializer(typeof(List<IAuto>));
            using (var fs=new FileStream("../../Auto.xml",FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,autoList);
                fs.Close();
            }
        }

        public void Load(List<IAuto> autoList)
        {
            var serializer= new XmlSerializer(typeof(List<IAuto>));
            using (var fs=new FileStream("../../Auto.xml",FileMode.OpenOrCreate))
            {
                var autos = (IAuto[]) serializer.Deserialize(fs);
                foreach (var auto in autos)
                {
                    autoList.Add(auto);
                }
                fs.Close();
            }
        }
    }
}