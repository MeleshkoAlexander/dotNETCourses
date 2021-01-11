using System;

namespace AutomationStation
{
    public class CallInfo
    {
        public PhoneNumber Source { get; }
        public PhoneNumber Target { get; }
        public DateTime Started { get; }
        public DateTime Ended { get; private set; }
       public TimeSpan Duration { get; private set; }

        public CallInfo(PhoneNumber source,PhoneNumber taret,DateTime started)
        {
            Source = source;
            Target = taret;
            Started = started;
        }

        public void EndCall(DateTime time)
        {
            Ended = time;
            CalculateDuration();
        }

        private void CalculateDuration()
        {
            Duration = Ended - Started;
        }
    }
}