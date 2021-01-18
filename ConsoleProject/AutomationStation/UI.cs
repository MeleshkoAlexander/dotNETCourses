using System;
using System.Collections.Generic;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Responds;
using ConsoleProject.Interfaces;

namespace ConsoleProject.AutomationStation
{
    public class UI : IUserInterface
    {
        private IInputOutput _inputOutput;
        private StationConsole _stationConsole;

        public UI(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
            _stationConsole = new StationConsole();
        }

        public void Menu()
        {
            var choose = 0;
            while (true)
            {
                InputMenu();
                choose =Convert.ToInt32(_inputOutput.OutputMessage(">>"));
                switch (choose)
                {
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    case 1:
                    {
                        _stationConsole.ContractManager.NewContract();
                        break;
                    }
                    case 2:
                    {
                        InputTerminals();
                        var terminal = _stationConsole.Terminals[Convert.ToInt32(_inputOutput.OutputMessage(">>"))];
                        TerminalMenu(terminal);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void TerminalMenu(Terminal terminal)
        {
            
        }

        private void InputMenu()
        {
            _inputOutput.InputMessage("0.Exit");
            _inputOutput.InputMessage("1.Register new contract");
            _inputOutput.InputMessage("2.Choose terminal");
        }

        private void InputTerminals()
        {
            var i = 0;
            foreach (var terminal in _stationConsole.Terminals)
            {
                _inputOutput.InputMessage($"{i++}.{terminal.Number}");
            }
        }
    }
}