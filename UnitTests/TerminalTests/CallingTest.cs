using System.Collections;
using System.Collections.Generic;
using System.Threading;
using AutomationStation.Billing;
using AutomationStation.Models;
using Xunit;

namespace UnitTests.TerminalTests
{
    public class CallingTest
    {
        [Theory]
        [MemberData(nameof(TerminalTargetTerminalSource))]
        public void CallTest(Terminal terminal1,Terminal terminal2)
        {
            var ports = new List<Port>() {new Port(), new Port()};
            terminal1.Plug(ports[0]);
            terminal2.Plug(ports[1]);
            var subscribers = new List<BillingSubscriber>() {new BillingSubscriber(terminal1.Number),new BillingSubscriber(terminal2.Number)};
            var billingStation = new BillingStation(subscribers);
            var station = new Station(ports, billingStation);
            station.NewRequestWaiting(ports[0]);
            station.NewRequestWaiting(ports[1]);
            terminal1.Call(terminal2.Number);
            terminal2.Port.IncomingRequest += ((sender, request) => Assert.Equal(request.Source,terminal1.Number));
            terminal2.Port.IncomingRequest -= ((sender, request) => Assert.Equal(request.Source,terminal1.Number));
            terminal2.Answer();
            terminal1.Port.StationRespond += ((sender, respond) => Assert.Equal(respond.AcceptMessage, "Call Started"));
            terminal1.Port.StationRespond -= ((sender, respond) => Assert.Equal(respond.AcceptMessage, "Call Started"));
            Thread.Sleep(1000);
            terminal1.EndCall();
            terminal2.Port.CallEnd += ((sender, args) => Assert.Equal(sender, terminal1));
            terminal2.Port.CallEnd -= ((sender, args) => Assert.Equal(sender, terminal1));
            var stats = subscribers[0].GetStats();
            foreach (var callInfo in stats)
            {
                Assert.Equal(callInfo.Source,terminal1.Number);
                Assert.Equal(callInfo.Target,terminal2.Number);
                Assert.NotNull(callInfo.Started);
                Assert.NotNull(callInfo.Ended);
            }
        }

        public static IEnumerable<object[]> TerminalTargetTerminalSource()
        {
            yield return new object[] {new Terminal(new PhoneNumber("113")), new Terminal(new PhoneNumber("112"))};
            yield return new object[] {new Terminal(new PhoneNumber("112")), new Terminal(new PhoneNumber("111"))};
        }
    }
}