using System;
using System.Text.Json.Serialization;
using AutomationStation.Exception;
using AutomationStation.Interfaces;
using AutomationStation.Responds;

namespace AutomationStation.Models
{
    public class Terminal: ITerminal
    {
        public PhoneNumber Number { get; }
        public Port Port { get; private set; }
        public Terminal()
        {}

        public void Call(PhoneNumber target)
        {
            if (this.Port == null) throw new PortNullException();
            if (target == Number) throw new IncorrectNumberException();
            if (Port.State == PortState.Free)
            {
                Port.OnOutgoingRequest(this,target);
            }
        }

        public void Answer()
        {
            if (this.Port == null) throw new PortNullException();
            Port.OnCallRespond(new Respond(){Request = Port.CurrentRequest, State=RespondState.Accept});
        }

        public void Decline()
        {
            if (this.Port == null) throw new PortNullException();
            Port.OnCallRespond(new Respond(){Request = Port.CurrentRequest, State=RespondState.Decline});
        }

        public void EndCall()
        {
            Port.OnEndCall(Port);
        }
        public void Plug(Port port)
        {
            this.Port = port;
            this.Port.Plug(this);
        }

        public void UnPlug()
        {
            this.Port.UnPlug();
            this.Port = null;
        }

        public Terminal(PhoneNumber number)
        {
            this.Number = number;
        }
    }
}