using System;
using System.Security.Policy;
using AutomationStation.Interfaces;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace AutomationStation
{
    public class Port : IPort
    {
        public PortState State { get; set; }
        public Station Station { get; }
        public Terminal Terminal { get; }

        public Port(Station station, Terminal terminal)
        {
            this.Station = station;
            this.Terminal = terminal;
        }
        
        public event EventHandler<OutgoingRequest> OutgoingRequest;
        public event EventHandler<Respond> CallRespond;

        public void OnOutgoingRequest(object sender, PhoneNumber target)
        {
            OutgoingRequest?.Invoke(sender, new Requests.OutgoingRequest() {Source = Terminal.Number, Target = target});
        }
        
        public void NewIncomingRequest(PhoneNumber source)
        {
            Terminal.OnIncomingRequest(this, new IncomingRequest() {Source = source});
        }

        public void NewCallRespond(object sender, Respond respond)
        {
            CallRespond?.Invoke(sender, respond);
        }
    }
}