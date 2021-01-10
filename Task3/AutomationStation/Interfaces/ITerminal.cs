using System;

namespace AutomationStation.Interfaces
{
    public interface ITerminal
    {
        PhoneNumber Number { get; }
        Port Port { get; }
        event EventHandler<Requests.IncomingRequest> IncomingRequest;
        event EventHandler<Requests.OutgoingRequest> OutgoingRequest; 
        void OnOutgoingRequest();
        void OnIncomingRequest(object sender,Requests.IncomingRequest request);
        void Answer();
        void Drop();
    }
}