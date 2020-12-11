using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using TaxiCompany.Auto;
using TaxiCompany.Store;

namespace TaxiCompany.TaxiCompany
{
    public class TaxiCompany<TAutoType> where TAutoType: IAuto
    {
        private readonly List<TAutoType> _taxiList;

        public TaxiCompany()
        {
            this._taxiList = new List<TAutoType>();
        }

        public void Load()
        {
            var xmlStore=new Store.XmlStore();
            xmlStore.Load(this._taxiList);
        }

        public void Save()
        {
            var xmlStore=new Store.XmlStore();
            xmlStore.Save(this._taxiList);
        }

        public void Add(TAutoType auto)
        {
            _taxiList.Add(auto);
        }

        public void Delete(TAutoType auto)
        {
            if (!this._taxiList.Remove(auto))
            {
                throw new ArgumentException("Remove failed");
            }
        }

        public List<TAutoType> GetCopy()
        {
            var newTaxiList = new List<TAutoType>();
            newTaxiList.AddRange(_taxiList);
            return newTaxiList;
        }
    }
}