using System;
using AutomationStation.Interfaces;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace AutomationStation.Models
{
    public class Port : IPort
    {
        public PortState State { get; set; } = PortState.Disabled;
        public Terminal Terminal { get; private set; }
        public Requests.Request CurrentRequest;
        
        public Port()
        {}


        public event EventHandler<IncomingRequest> IncomingRequest;

        private void OnIncomingRequest(object sender, Requests.IncomingRequest request)
        {
            IncomingRequest?.Invoke(sender, request);
            CurrentRequest = request;
        }

        public void NewIncomingRequest(PhoneNumber source)
        {
            OnIncomingRequest(this, new IncomingRequest() {Source = source});
        }

        public event EventHandler<OutgoingRequest> OutgoingRequest;

        public void OnOutgoingRequest(object sender, PhoneNumber target)
        {
            OutgoingRequest?.Invoke(sender, new Requests.OutgoingRequest() {Source = Terminal.Number, Target = target});
        }

        public event EventHandler<StationRespond> StationRespond;

        private void OnStationRespond(object sender, StationRespond respond)
        {
            StationRespond?.Invoke(sender, respond);
        }

        public void NewStationRespond(StationRespond respond)
        {
            OnStationRespond(this, respond);
        }

        public event EventHandler<Respond> CallRespond;

        public void OnCallRespond(Respond respond)
        {
            CallRespond?.Invoke(this, respond);
        }
        public event EventHandler CallEnd;

        public void OnEndCall(object sender)
        {
            CallEnd?.Invoke(sender,new EventArgs());
        }
        public void Plug(Terminal terminal)
        {
            this.Terminal = terminal;
            State = PortState.Free;
        }

        public void UnPlug()
        {
            State = PortState.Disabled;
            this.Terminal = null;
        }
    }
}