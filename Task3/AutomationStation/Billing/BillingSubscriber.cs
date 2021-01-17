using System.Collections.Generic;
using System.Linq;
using AutomationStation.Models;
using AutomationStation.Store;

namespace AutomationStation.Billing
{
    public class BillingSubscriber
    {
        public PhoneNumber Number { get; }
        private readonly List<CallInfo> _callInfoCollection;
        private string _path;
        private double _payment;
        private readonly IStore _store;
    
        public BillingSubscriber(string path,PhoneNumber number)
        {
            Number = number;
            _store = new JsonStore();
            _path = path;
            _callInfoCollection = new List<CallInfo>();
            LoadCallInfoCollection();
        }

        ~BillingSubscriber()
        {
            SaveCallInfoCollection();
        }

        private void LoadCallInfoCollection()
        {
            _store.LoadCollection(_callInfoCollection,_path);
        }

        public void SaveCallInfoCollection()
        {
            _store.SaveCollection(_callInfoCollection,_path);
        }

        public void AddCallInfo(CallInfo callInfo)
        {
            _callInfoCollection.Add(callInfo);
        }

        private void CalculatePayment()
        {
            _payment = _callInfoCollection.Select(info => info.Cost).Sum();
        }

        public double GetPayment()
        {
            return _payment;
        }

        public List<CallInfo> GetStats()
        {
            return _callInfoCollection;
        }
    }
}