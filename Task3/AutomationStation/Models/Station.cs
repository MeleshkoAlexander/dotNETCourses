using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using AutomationStation.Billing;
using AutomationStation.Interfaces;
using AutomationStation.Requests;

namespace AutomationStation.Models
{
    public class Station : IShouldClearEvents
    {
        private readonly List<Port> _portCollection;
        private readonly BillingStation _billingStation;

        public Station(List<Port> portCollection, BillingStation billingStation)
        {
            _portCollection = portCollection;
            _billingStation = billingStation;
        }
        
        public void NewRequestWaiting(Port port)
        {
            port.OutgoingRequest += HasNewRequestAsynс;
        }

        private async void HasNewRequestAsynс(object sender, OutgoingRequest request)
        {
            await Task.Run(() => HasNewRequest(sender, request));
        }
        private void HasNewRequest(object sender,OutgoingRequest request)
        {
            var handler = new RequestHandler(request.Source, request.Target, _portCollection,GetTariff());
            handler.CreateNewRequest(request);
            _billingStation.NewCallInfo(handler.GetCallInfo());
        }

        private double GetTariff()
        {
            return Convert.ToDouble(ConfigurationManager.AppSettings.Get("Tariff"));
        }

        public void ClearEvents()
        {
            _portCollection.Clear();
        }
    }
}