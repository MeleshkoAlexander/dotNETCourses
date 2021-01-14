using System;
using System.Collections.Generic;
using System.Linq;
using AutomationStation.Interfaces;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace AutomationStation
{
    public class Station : IShouldClearEvents
    {
        private readonly List<Port> _portCollection;
        private List<Port> _connectionCollection;

        public Station(List<Port> portCollection)
        {
            _portCollection = portCollection;
            _connectionCollection = new List<Port>();
        }

        public void HasNewRequest()
        {
            foreach (var port in _portCollection)
            {
                port.OutgoingRequest += (sender, request) => CreateNewRequest(request);
            }
        }

        private void CreateNewRequest(OutgoingRequest request)
        {
            foreach (var port in _portCollection.Where(port => port.Terminal.Number.Equals(request.Target)))
            {
                var message = "";
                switch (port.State)
                {
                    case PortState.Busy:
                        message = "Subscriber is busy now";
                        break;
                    case PortState.Disabled:
                        message = "Subscriber is not available now";
                        break;
                    case PortState.Free:
                        port.State = PortState.Busy;
                        port.NewIncomingRequest(request.Source);
                        port.CallRespond += ((sender, respond) => GetRespond((Port) sender, respond));
                        port.CallRespond -= ((sender, respond) => GetRespond((Port) sender, respond));
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                port.NewStationRespond(new StationRespond()
                    {Request = request, DeclineMessage = message, State = RespondState.Decline});
            }
        }

        private void GetRespond(IPort sender, Respond respond)
        {
            if (respond.State == RespondState.Accept)
            {
                AcceptRespond(sender, respond);
            }
            else DeclineRespond(sender,respond);
        }

        private void AcceptRespond(IPort sender, Respond respond)
        {
            CreateCall(sender.Terminal.Number, respond.Request.Source);
        }

        private void DeclineRespond(IPort sender,Respond respond)
        {
            const string message = "Call rejected";
            ((Port) sender).NewStationRespond(new StationRespond()
                {Request = respond.Request, DeclineMessage = message, State = RespondState.Decline});
        }

        private void CreateCall(PhoneNumber source, PhoneNumber target)
        {
            //TODO Create call
        }

        public void ClearEvents()
        {
            _portCollection.Clear();
        }
    }
}