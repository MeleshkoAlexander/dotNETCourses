using System.Security.Policy;
using AutomationStation.Interfaces;

namespace AutomationStation
{
    public class Port:IPort
    {
        public PortState State { get; set; }
        public Station Station { get; }
        public Terminal Terminal { get; }

        public Port(Station station, Terminal terminal)
        {
            this.Station = station;
            this.Terminal = terminal;
        }
    }
}