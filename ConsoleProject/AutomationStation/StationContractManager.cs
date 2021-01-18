using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Requests;
using AutomationStation.Store;

namespace ConsoleProject.AutomationStation
{
    public class StationContractManager
    {
        private List<Terminal> _terminals;
        private readonly List<Port> _ports;
        private readonly List<BillingSubscriber> _billingSubscribers;

        public StationContractManager( List<Terminal> terminals,List<Port> ports,List<BillingSubscriber> subscribers)
        {
            _terminals = terminals;
            _ports = ports;
            _billingSubscribers = subscribers;
        }

        public Terminal NewContract()
        {
            var random = new Random();
            var number = new PhoneNumber(random.Next(100, 1000).ToString());
            var terminal = new Terminal(number);
            var subscriber = new BillingSubscriber("Stats" + number.ToString() + ".json", number);
            _terminals.Add(terminal);
            _billingSubscribers.Add(subscriber);
            return terminal;
        }

        public Port GetFreePort()
        {
            foreach (var port in _ports.Where(port => port.State == PortState.Disabled))
            {
                return port;
            }
            return MakeFreePort();
        }

        private Port MakeFreePort()
        {
            var port = new Port();
            _ports.Add(port);
            return port;
        }
    }
}