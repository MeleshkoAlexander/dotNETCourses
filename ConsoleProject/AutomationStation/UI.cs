using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomationStation.Billing;
using AutomationStation.Models;
using AutomationStation.Responds;
using ConsoleProject.Interfaces;

namespace ConsoleProject.AutomationStation
{
    public class UI : IUserInterface
    {
        private IInputOutput _inputOutput;
        private List<Port> _ports;
        private List<Terminal> _terminals;
        private List<BillingSubscriber> _subscribers;
        private ContractManager _manager;
        private Station _station;

        public UI(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
            _ports = new List<Port>();
            _terminals = new List<Terminal>();
            _subscribers = new List<BillingSubscriber>();
            _manager = new ContractManager(_ports, _terminals, _subscribers);
            CreateNewContracts();
            var billingStation = new BillingStation(_subscribers);
            _station = new Station(_ports, billingStation);
            foreach (var port in _ports)
            {
                _station.NewRequestWaiting(port);
            }
        }

        public void Menu()
        {
            var random = new Random();
            MakeCall(_terminals[0], _terminals[1], random);
            MakeCall(_terminals[0], _terminals[2], random);
            MakeCall(_terminals[1], _terminals[0], random);
            MakeCall(_terminals[1], _terminals[2], random);
            MakeCall(_terminals[2], _terminals[0], random);
            MakeCall(_terminals[2], _terminals[1], random);
            foreach (var subscriber in _subscribers)
            {
                InputStats(subscriber.GetStats());
            }
        }

        private void InputStats(List<CallInfo> CallStats)
        {
            foreach (var info in CallStats)
            {
                _inputOutput.InputMessage($"{info.Source} call {info.Target}");
                _inputOutput.InputMessage(
                    $"Started {info.Started.Day}.{info.Started.Month}.{info.Started.Year} " +
                    $" {info.Started.Hour}:{info.Started.Minute}:{info.Started.Second}");
                _inputOutput.InputMessage($"Duration {info.Duration.Hours}:{info.Duration.Minutes}:{info.Duration.Seconds}");
                _inputOutput.InputMessage($"Cost {info.Cost}$");
            }
        }

        private void CreateNewContracts()
        {
            _manager.NewContract();
            _manager.NewContract();
            _manager.NewContract();
            foreach (var terminal in _terminals)
            {
                terminal.Plug(_manager.GetFreePort());
            }
        }

        private void MakeCall(Terminal source, Terminal target, Random random)
        {
            source.Call(target.Number);
            target.Port.IncomingRequest += ((sender, request) => _inputOutput.InputMessage(request.Source.ToString()));
            target.Answer();
            source.Port.StationRespond += ((sender, respond) => _inputOutput.InputMessage(
                respond.State == RespondState.Accept
                    ? respond.AcceptMessage
                    : respond.DeclineMessage));
            Thread.Sleep(random.Next(1000,2000));
            target.EndCall();
            source.Port.CallEnd += ((sender, args) =>
                _inputOutput.InputMessage($"{((Port) sender).Terminal.Number} ended the call"));
        }
    }
}