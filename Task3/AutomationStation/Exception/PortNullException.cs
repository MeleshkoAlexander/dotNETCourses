using System;

namespace AutomationStation.Exception
{
    public class PortNullException : NullReferenceException
    {
        public PortNullException(string message = "Your terminal has not connected to port") 
            : base(message)
        {
        }
    }
}