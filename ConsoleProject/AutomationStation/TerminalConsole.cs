using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomationStation.Billing;
using AutomationStation.Exception;
using AutomationStation.Models;
using AutomationStation.Requests;
using AutomationStation.Responds;
using ConsoleProject.Interfaces;

namespace ConsoleProject.AutomationStation
{
    public class TerminalConsole
    {
        private Terminal _terminal;

        public TerminalConsole(Terminal terminal)
        {
            _terminal = terminal;
        }

        public void Plug(Port port)
        {
            if (_terminal.Port != null) return;
            _terminal.Plug(port);
        }

        public void UnPlug()
        {
            if (_terminal.Port == null) return;
            _terminal.UnPlug();
        }

        public string Call(PhoneNumber target)
        {
            _terminal.Call(target);
            var message = "";
            _terminal.Port.StationRespond += ( (sender, respond) => message = StationRespond(sender, respond));
            return message;
        }

        private string StationRespond(object sender, StationRespond respond)
        {
            return respond.State switch
            {
                RespondState.Accept => respond.AcceptMessage,
                RespondState.Decline => respond.DeclineMessage,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void HaveNewRequest(object sender,IncomingRequest request)
        {
            
        }
    }
}