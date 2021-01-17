using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AutomationStation.Models;

namespace AutomationStation.Billing
{
    public class CallInfo

    {
        public CallState State { get; set; }
        public PhoneNumber Source { get; }
        public PhoneNumber Target { get; }
        public DateTime Started { get; private set; }
        public DateTime Ended { get; private set; }
        public TimeSpan Duration { get; private set; }
        public double Cost { get; private set; }
        private double _tariff;

        public CallInfo(PhoneNumber source, PhoneNumber target, double tariff)
        {
            Source = source;
            Target = target;
            _tariff = tariff;
        }

        private CallInfo()
        {
        }

        public void Start(DateTime time)
        {
            Started = time;
        }

        public void End(DateTime time)
        {
            Ended = time;
            CalculateDuration();
            CalculateCost();
        }

        private void CalculateDuration()
        {
            Duration = Ended - Started;
        }

        private void CalculateCost()
        {
            Cost = Duration.Minutes * _tariff;
        }
    }
}