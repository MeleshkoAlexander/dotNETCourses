using System;
using System.Collections.Generic;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Responds;

namespace ConsoleProject.AutomationStation
{
    public class UI
    {
        private StationConsole _station;

        public UI()
        {
            _station = new StationConsole();
        }

        public void Menu()
        {
            while (true)
            {
                InputMenu();
                var choose = Convert.ToInt32(IOC.OutputMessage(">>"));
                switch (choose)
                {
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    case 1:
                    {
                        _station.GetNewContract();
                        break;
                    }
                    case 2:
                    {
                        InputTerminals();
                        TerminalMenu(Convert.ToInt32(IOC.OutputMessage(">>")));
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void InputMenu()
        {
            IOC.InputMessage("0.Exit");
            IOC.InputMessage("1.Register new terminal");
            IOC.InputMessage("2.Choose Terminal");
        }

        private void InputTerminals()
        {
            var i = 0;
            foreach (var terminal in _station.GetTerminals())
            {
                IOC.InputMessage($"{i++}: "+ terminal.Number.Number);
            }
        }

        private void TerminalMenu(int index)
        {
            var terminal = _station.GetTerminals()[index];
            var terminalConsole = new TerminalConsole(terminal,_station.GetSubscriberByNumber(terminal.Number));
            Console.Clear();
            terminalConsole.WaitRequest();
            while (true)
            {
                IOC.InputMessage("Your number "+ terminalConsole.GetNumber());
                IOC.InputMessage(terminalConsole.HavePort()
                    ? terminalConsole.GetState().ToString()
                    : "Don't have a port");
                InputTerminalMenu();
                var choose = Convert.ToInt32(IOC.OutputMessage(">>"));
                switch (choose)
                {
                    case 0:
                    {
                        return;
                    }
                    case 1:
                    {
                        terminalConsole.Plug(_station.GetPort());
                        break;
                    }
                    case 2:
                    {
                        terminalConsole.UnPlug();
                        break;
                    }
                    case 3:
                    {
                       terminalConsole.Call(new PhoneNumber(IOC.OutputMessage("Input number")));
                        break;
                    }
                    case 4:
                    {
                        InputStats(terminalConsole.GetStats());
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void InputTerminalMenu()
        {
            IOC.InputMessage("0.Exit");
            IOC.InputMessage("1.Plug");
            IOC.InputMessage("2.UnPlug");
            IOC.InputMessage("3.Call");
            IOC.InputMessage("4.Stats");
        }

        private void InputStats(List<CallInfo> callInfos)
        {
            foreach (var info in callInfos)
            {
                IOC.InputMessage(info.Target.Number);
                IOC.InputMessage($"{info.Started.Hour}:{info.Started.Minute}:{info.Started.Second}");
                IOC.InputMessage($"{info.Ended.Hour}:{info.Ended.Minute}:{info.Ended.Second}");
                IOC.InputMessage($"{info.Duration.Hours}:{info.Duration.Minutes}:{info.Duration.Seconds}");
                IOC.InputMessage($"{info.Cost}$");
            }
        }
    }
}