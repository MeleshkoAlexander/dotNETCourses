using System;
using AutomationStation.Models;

namespace AutomationStation.Billing
{
    [Serializable]
    public class CallInfo
    {
        public CallState State { get; set; }
        public PhoneNumber Source { get; private set; }
        public PhoneNumber Target { get; private set; }
        public DateTime Started { get; private set; }
        public DateTime Ended { get; private set; }
        public TimeSpan Duration { get; private set; }
        public double Cost { get; private set; }
        private double tariff;

        public CallInfo(PhoneNumber source, PhoneNumber taret,double tariff)
        {
            Source = source;
            Target = taret;
            this.tariff = tariff;
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
            Cost = Duration.Minutes * tariff;
        }
    }
}