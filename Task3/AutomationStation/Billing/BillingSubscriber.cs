using System.Collections.Generic;
using System.Linq;
using AutomationStation.Models;
using AutomationStation.Store;

namespace AutomationStation.Billing
{
    public class BillingSubscriber
    {
        public PhoneNumber Number { get; private set; }
        private readonly List<CallInfo> _callInfoCollection;
        private readonly string _path;
        private double _monthPayment;

        public BillingSubscriber(string path,PhoneNumber number)
        {
            Number = number;
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
            var store = new XMLStore(_path);
            store.LoadCollection(_callInfoCollection);
        }

        private void SaveCallInfoCollection()
        {
            var store = new XMLStore(_path);
            store.SaveCollection(_callInfoCollection);
        }

        public void AddCallInfo(CallInfo callInfo)
        {
            _callInfoCollection.Add(callInfo);
        }

        private void CalculatePayment()
        {
            _monthPayment = _callInfoCollection.Select(info => info.Cost).Sum();
        }

        public double GetPayment()
        {
            return _monthPayment;
        }

        public List<CallInfo> GetStats()
        {
            return _callInfoCollection;
        }
    }
}