using System;
using AutomationStation.Interfaces;
using AutomationStation.Responds;

namespace AutomationStation.Models
{
    public class Terminal: ITerminal
    {
        public PhoneNumber Number { get; }
        public Port Port { get; private set; }

        public void Call(PhoneNumber target)
        {
            if (this.Port == null) throw new NullReferenceException("Your terminal has not connected to port");
            if (Port.State == PortState.Free)
            {
                Port.OnOutgoingRequest(this,target);
            }
        }

        public void Answer()
        {
            if (this.Port == null) throw new NullReferenceException("Your terminal has not connected to port");
            Port.OnCallRespond(this,new Respond(){Request = Port.CurrentRequest, State=RespondState.Accept});
        }

        public void Drop()
        {
            if (this.Port == null) throw new NullReferenceException("Your terminal has not connected to port");
            Port.OnCallRespond(this,new Respond(){Request = Port.CurrentRequest, State=RespondState.Decline});
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