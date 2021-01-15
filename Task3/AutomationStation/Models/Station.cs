using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationStation.Billing;
using AutomationStation.Interfaces;
using AutomationStation.Requests;

namespace AutomationStation.Models
{
    public class Station : IShouldClearEvents
    {
        private readonly List<Port> _portCollection;
        private BillingStation _billingStation;

        public Station(List<Port> portCollection, BillingStation billingStation)
        {
            _portCollection = portCollection;
            _billingStation = billingStation;
        }

        private Port GetPortByNumber(PhoneNumber number)
        {
            return _portCollection.FirstOrDefault(port => port.Terminal.Number == number);
        }


        public async void NewRequestWaiting()
        {
            foreach (var port in _portCollection)
            {
                port.OutgoingRequest += HasNewRequestAsynk;
            }
        }

        private async void HasNewRequestAsynk(object sender, OutgoingRequest request)
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
            return 0.2;
        }
        

        /*private void CreateNewRequest(OutgoingRequest request)
        {
            var port = GetPortByNumber(request.Target);
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

        private void GetRespond(IPort sender, Respond respond)
        {
            if (respond.State == RespondState.Accept)
            {
                AcceptRespond(sender, respond);
            }
            else DeclineRespond(sender, respond);
        }

        private void AcceptRespond(IPort sender, Respond respond)
        {
            CreateCall(sender.Terminal.Number, respond.Request.Source);
        }

        private void DeclineRespond(IPort sender, Respond respond)
        {
            const string message = "Call rejected";
            ((Port) sender).NewStationRespond(new StationRespond()
                {Request = respond.Request, DeclineMessage = message, State = RespondState.Decline});
        }

        private void CreateCall(PhoneNumber source, PhoneNumber target)
        {
            if (source == target) throw new Exception("Incorrect Number");
            var sourcePort = GetPortByNumber(source);
            var targetPort = GetPortByNumber(target);
            const string message = "Call Started";
            sourcePort.NewStationRespond(new StationRespond(){Request = sourcePort.CurrentRequest, State = RespondState.Accept, AcceptMessage = message});
            targetPort.NewStationRespond(new StationRespond(){Request = sourcePort.CurrentRequest,State = RespondState.Accept, AcceptMessage = message});
        }*/

        public void ClearEvents()
        {
            _portCollection.Clear();
        }
    }
}