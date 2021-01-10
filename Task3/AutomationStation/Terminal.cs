using System;
using AutomationStation.Interfaces;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace AutomationStation
{
    public class Terminal: ITerminal
    {
        public PhoneNumber Number { get; }
        public Port Port { get; }
        public Requests.Request ServerIncomingRequest;

        public void Call(PhoneNumber target)
        {
            if (Port.State == PortState.Free)
            {
                Port.OnOutgoingRequest(this,target);
            }
        }

        public void Answer()
        {
            Port.NewCallRespond(this,new Respond(){Request = ServerIncomingRequest, State=RespondState.Accept});
        }

        public void Drop()
        {
            Port.NewCallRespond(this,new Respond(){Request = ServerIncomingRequest, State=RespondState.Drop});
        }

        public Terminal(PhoneNumber number, Port port)
        {
            this.Number = number;
            this.Port = port;
        }
    }
}