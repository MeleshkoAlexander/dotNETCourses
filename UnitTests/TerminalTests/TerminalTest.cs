using System;
using AutomationStation.Models;
using Xunit;

namespace UnitTests.TerminalTests
{
    public class TerminalTest
    {
        
        [Fact]
        public void TestPlug()
        {
            var number = new PhoneNumber("111");
            var terminal = new Terminal(number);
            var port = new Port();
            Assert.Null(terminal.Port);
            terminal.Plug(port);
            Assert.NotNull(terminal.Port);
        }

        [Fact]
        public void TestUnPlug()
        {
            var number = new PhoneNumber("111");
            var terminal = new Terminal(number);
            var port = new Port();
            terminal.Plug(port);
            Assert.NotNull(terminal.Port);
            terminal.UnPlug();
            Assert.Null(terminal.Port);
        }
        [Fact]
        public void TestNumber()
        {
            var number = new PhoneNumber("111");
            var terminal = new Terminal(number);
            Assert.Equal(terminal.Number,number);
            number = new PhoneNumber("112");
            Assert.NotEqual(terminal.Number,number);
        }
    }
}