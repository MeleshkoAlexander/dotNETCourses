using System.Resources;
using TaxiCompany.Auto;

namespace TaxiCompany.Store
{
    public interface IStore
    {
        void Save(IAuto auto);
        IAuto Get(int id);
        void Delete(IAuto auto);
    }
}