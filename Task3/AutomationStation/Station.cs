using System;
using System.Collections.Generic;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace AutomationStation
{
    public class Station
    {
        private IEnumerable<Port> _portCollection;

        public Station(IEnumerable<Port> portCollection)
        {
            _portCollection = portCollection;
        }

        public void HasNewRequest()
        {
            foreach (var port in _portCollection)
            {
                port.OutgoingRequest += (sender, request) => CreateNewRequest(request);
            }
        }

        public void CreateNewRequest(OutgoingRequest request)
        {
            foreach (var port in _portCollection)
            {
                if (port.Terminal.Number.Equals(request.Target)&& port.State == PortState.Free)
                {
                    port.NewIncomingRequest(request.Source);
                    port.CallRespond += ((sender, respond) => GetRespond(respond));
                }
            }
        }

        public void GetRespond(Respond respond)
        {
            if (respond.State == RespondState.Accept)
            {
               //TODO respond handling
            }
        }

        private void CreateCall(PhoneNumber source,PhoneNumber target)
        {
            //TODO Create call
        }
    }
}