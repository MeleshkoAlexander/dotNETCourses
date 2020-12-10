using System;
using System.Collections.Generic;
using System.Linq;
using TaxiCompany.Auto;

namespace TaxiCompany.TaxiCompany
{
    public class TaxiCompanySelection
    {
        public static List<TAutoType> FindBySpeed<TAutoType>(List<TAutoType> autoList, double minLimit, double maxLimit)
            where TAutoType : IAuto
        {
            return autoList.Where(auto => auto.MaxSpeed >= minLimit && auto.MaxSpeed <= maxLimit).ToList();
        }
    }
}