using System.Collections.Generic;
using System.Resources;
using TaxiCompany.Auto;

namespace TaxiCompany.Store
{
    public interface IStore
    {
        void Save(List<IAuto> autoList);
        void Load(List<IAuto> autoList);
    }
}