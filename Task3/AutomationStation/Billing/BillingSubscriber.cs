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
        private readonly string _path;
        private double _payment;
        private readonly IStore _store;
    
        public BillingSubscriber(string path,PhoneNumber number)
        {
            Number = number;
            _store = new JsonStore();
            _path = path;
            _callInfoCollection = new List<CallInfo>();
            CalculatePayment();
        }
        public BillingSubscriber(PhoneNumber number)
        {
            Number = number;
            _callInfoCollection = new List<CallInfo>();
            CalculatePayment();
        }
        public BillingSubscriber()
        {}

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