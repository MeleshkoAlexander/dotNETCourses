using System;
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
        private List<Terminal> _terminals;
        private List<Port> _ports;
        private List<BillingSubscriber> _billingSubscribers;
        private BillingStation _billingStation;
        private Station _station;

        public StationConsole(List<Terminal> terminals,List<Port> ports, List<BillingSubscriber> billingSubscribers, BillingStation billingStation, Station station)
        {
            _terminals = terminals;
            _ports = ports;
            _billingSubscribers = billingSubscribers;
            _billingStation = billingStation;
            _station = station;
        }

        public StationContractManager ContractManager { get; }
        public List<Terminal> Terminals => _terminals;

        public StationConsole()
        {
            _terminals = new List<Terminal>();
            _ports = new List<Port>();
            _billingSubscribers = new List<BillingSubscriber>();
            _billingStation = new BillingStation(_billingSubscribers);
            _station = new Station(_ports,_billingStation);
            ContractManager = new StationContractManager(_terminals,_ports,_billingSubscribers);
        }

        /*public void Initialize()
        {
            _store.LoadCollection(_terminals,ConfigurationManager.AppSettings.Get("Terminals"));
            _store.LoadCollection(_ports,ConfigurationManager.AppSettings.Get("Ports"));
            _store.LoadCollection(_billingSubscribers,ConfigurationManager.AppSettings.Get("Subscribers"));
        }

        ~StationConsole()
        {
            _store.SaveCollection(_terminals,ConfigurationManager.AppSettings.Get("Terminals"));
            _store.SaveCollection(_ports,ConfigurationManager.AppSettings.Get("Ports"));
            _store.SaveCollection(_billingSubscribers,ConfigurationManager.AppSettings.Get("Subscribers"));
        }*/
        
    }
}