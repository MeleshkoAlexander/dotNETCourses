using System;

namespace AutomationStation.Exception
{
    public class IncorrectNumberException : ArgumentException
    {
        public IncorrectNumberException(string message) :
            base(message)
        {
        }
    }
}