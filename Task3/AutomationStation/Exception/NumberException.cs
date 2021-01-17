using System;

namespace AutomationStation.Exception
{
    public class IncorrectNumberException : ArgumentException
    {
        public IncorrectNumberException(string message="Incorrect number") :
            base(message)
        {
        }
    }
}