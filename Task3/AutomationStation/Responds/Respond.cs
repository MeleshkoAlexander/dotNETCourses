using AutomationStation.Requests;

namespace AutomationStation.Responds
{
    public class Respond
    {
        public Requests.Request Request;
        public RespondState State { get; set; }
    }
}