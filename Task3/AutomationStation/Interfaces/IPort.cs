using System;

namespace AutomationStation.Interfaces
{
    public interface IPort
    {
        PortState State { get; set; }
        Terminal Terminal { get; }
        event EventHandler<Requests.OutgoingRequest> OutgoingRequest;
        event EventHandler<Responds.Respond> CallRespond;
    }
}