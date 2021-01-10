using System;
using AutomationStation.Interfaces;

namespace AutomationStation
{
    public class Terminal: ITerminal
    {
        public PhoneNumber Number { get; }
        public Port Port { get; }
        public event EventHandler<Requests.IncomingRequest> IncomingRequest;
        public event EventHandler<Requests.OutgoingRequest> OutgoingRequest;
        public void OnOutgoingRequest()
        {
            throw new NotImplementedException();
        }
        public void OnIncomingRequest(object sender, Requests.IncomingRequest request)
        {
            IncomingRequest?.Invoke(sender,request);
        }

        public void Answer()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        public Terminal(PhoneNumber number, Port port)
        {
            this.Number = number;
            this.Port = port;
        }
    }
}