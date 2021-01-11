using System;

namespace AutomationStation.Interfaces
{
    public interface IPort
    {
        PortState State { get; set; }
        Station Station { get; }
        Terminal Terminal { get; }
        event EventHandler<Requests.OutgoingRequest> OutgoingRequest;
        event EventHandler<Responds.Respond> CallRespond;
    }
}