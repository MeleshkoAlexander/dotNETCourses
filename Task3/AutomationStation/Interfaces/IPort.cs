namespace AutomationStation.Interfaces
{
    public interface IPort
    {
        PortState State { get; set; }
        Station Station { get; }
        Terminal Terminal { get; }
    }
}