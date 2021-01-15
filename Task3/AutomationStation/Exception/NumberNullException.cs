using System;

namespace AutomationStation.Exception
{
    public class NumberNullException : ArgumentNullException
    {
        public NumberNullException(string message = "Number is null")
            : base(message)
        {
        }
    }
}