using System.Collections.Generic;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Store;
using System.Configuration;
using System.Linq;

namespace ConsoleProject.AutomationStation
{
    public class StationConsole
    {
        private List<Port> _portCollection;
        private BillingStation _billingStation;
        private List<BillingSubscriber> _subscribersCollection;
        private List<Terminal> _terminals;
        private Station _station;
        private StationContractManager _contractManager;

        public StationConsole()
        {
            _portCollection = new List<Port>();
            _subscribersCollection = new List<BillingSubscriber>();
            _terminals = new List<Terminal>();
            _billingStation = new BillingStation(_subscribersCollection);
            _station = new Station(_portCollection, _billingStation);
            _contractManager = new StationContractManager(_portCollection, _subscribersCollection);
        }

        public void GetNewContract()
        {
            var terminal = _contractManager.NewContract();
            terminal.Plug( GetPort());
            _terminals.Add(terminal);
        }

        public List<Terminal> GetTerminals()
        {
            return _terminals;
        }

        public Port GetPort()
        {
            var port = _contractManager.GetFreePort();
            _portCollection.Add(port);
            _station.NewRequestWaiting(port);
            return port;
        }

        public BillingSubscriber GetSubscriberByNumber(PhoneNumber number)
        {
            return _subscribersCollection?.First(subscriber => subscriber.Number == number);
        }
    }
}