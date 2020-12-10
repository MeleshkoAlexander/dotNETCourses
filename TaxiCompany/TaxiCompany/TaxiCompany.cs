using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using TaxiCompany.Auto;
using TaxiCompany.Store;

namespace TaxiCompany.TaxiCompany
{
    public class TaxiCompany<TAutoType> where TAutoType: IAuto
    {
        private List<TAutoType> taxiList;

        public void Load()
        {
            var xmlStore=new Store.XmlStore();
            xmlStore.Load(this.taxiList);
        }

        public void Save()
        {
            var xmlStore=new Store.XmlStore();
            xmlStore.Save(this.taxiList);
        }

        public void Add(TAutoType auto)
        {
            taxiList.Add(auto);
        }

        public void Delete(TAutoType auto)
        {
            if (!this.taxiList.Remove(auto))
            {
                throw new ArgumentException("Remove failed");
            }
        }

        public List<TAutoType> GetCopy()
        {
            var newTaxiList = new List<TAutoType>();
            newTaxiList.AddRange(taxiList);
            return newTaxiList;
        }
    }
}