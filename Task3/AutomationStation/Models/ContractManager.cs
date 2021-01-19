using System;
using System.Collections.Generic;
using System.Linq;
using AutomationStation.Billing;

namespace AutomationStation.Models
{
    public class ContractManager
    {
        private List<Port> _ports;
        private List<Terminal> _terminals;
        private List<BillingSubscriber> _subscribers;
        private Random _random;

        public ContractManager(List<Port> ports, List<Terminal> terminals, List<BillingSubscriber> subscribers)
        {
            _ports = ports;
            _terminals = terminals;
            _subscribers = subscribers;
            _random = new Random();
        }

        public Terminal NewContract()
        {
            var number = new PhoneNumber(CreateNewNumber());
            var terminal = new Terminal(number);
            var subscriber = new BillingSubscriber(number);
            _terminals.Add(terminal);
            _subscribers.Add(subscriber);
            return terminal;
        }

        private string CreateNewNumber()
        {
            return _random.Next(100, 1000).ToString();
        }

        public Port GetFreePort()
        {
            foreach (var port in _ports.Where(port => port.State == PortState.Disabled))
            {
                return port;
            }

            return MakeNewPort();
        }

        private Port MakeNewPort()
        {
            var port = new Port();
            _ports.Add(port);
            return port;
        }
    }
}