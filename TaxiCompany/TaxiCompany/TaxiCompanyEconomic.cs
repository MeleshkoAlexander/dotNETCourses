using System.Collections.Generic;
using System.Linq;
using TaxiCompany.Auto;

namespace TaxiCompany.TaxiCompany
{
    public class TaxiCompanyEconomic
    {
        public delegate int SortBy<TAutoType>(TAutoType a, TAutoType b) where TAutoType : IAuto;

        public static void Sort<TAutoType>(List<TAutoType> autoList, SortBy<TAutoType> sortBy) where TAutoType : IAuto
        {
            autoList.Sort((a, b) => sortBy(a, b));
        }

        public static double GetCompanyCost<TAutoType>(List<TAutoType> autoList) where TAutoType : IAuto
        {
            return autoList.Sum(auto => auto.Cost);
        }
    }
}