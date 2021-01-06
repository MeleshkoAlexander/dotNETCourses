using System.Collections.Generic;
using System.Resources;
using TaxiCompany.Auto;

namespace TaxiCompany.Store
{
    public interface IStore
    {
        void Save<TAutoType>(List<TAutoType> autoList)where TAutoType : IAuto;
        void Load<TAutoType>(List<TAutoType> autoList) where TAutoType : IAuto;
    }
}