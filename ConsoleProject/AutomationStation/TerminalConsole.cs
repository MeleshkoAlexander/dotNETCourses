using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Requests;
using AutomationStation.Responds;

namespace ConsoleProject.AutomationStation
{
    public class TerminalConsole
    {
        private Terminal _terminal;
        private BillingSubscriber _subscriber;

        public TerminalConsole(Terminal terminal, BillingSubscriber subscriber)
        {
            _terminal = terminal;
            _subscriber = subscriber;
        }

        public void Plug(Port port)
        {
            if(_terminal.Port!=null) return;
            _terminal.Plug(port);
        }

        public void UnPlug()
        {
            _terminal.UnPlug();
        }

        public string GetNumber()
        {
            return _terminal.Number.Number;
        }

        public List<CallInfo> GetStats()
        {
            return _subscriber.GetStats();
        }
        

        public PortState GetState()
        {
            return _terminal.Port.State;
        }

        public bool HavePort()
        {
            return _terminal.Port != null;
        }
        public void Call(PhoneNumber number)
        {
            var target = number;
            _terminal.Call(target);
            _terminal.Port.StationRespond += (sender, respond) =>
            {
                IOC.InputMessage(respond.State == RespondState.Accept
                    ? respond.AcceptMessage
                    : respond.DeclineMessage);
            };
        }

        public void WaitRequest()
        {
            _terminal.Port.IncomingRequest += RequestWaitAsync;
        }

        private async void RequestWaitAsync(object sender,IncomingRequest request)
        {
            await Task.Run((() => NewRequest(sender, request)));
        }

        private void NewRequest(object sender,IncomingRequest request)
        {
            _terminal.Answer();
            /*while (true)
            {
                IOC.InputMessage("1.Accept");
                IOC.InputMessage("2.Decline");
                var choose = Convert.ToInt32(IOC.OutputMessage(">>"));
                switch (choose)
                {
                    case 1:
                    {
                        _terminal.Answer();
                        return;
                    }
                    case 2:
                    {
                        _terminal.Drop();
                        return;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }*/
        }
    }
}