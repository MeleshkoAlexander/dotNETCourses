namespace TaxiCompany.Auto
{
    public interface IAuto
    {
        string Name { get; }
        float Consumption { get; }
        double Cost { get; }
        int Year { get; }
        string StatenNumber { get; }
        string Vin { get; }
    }
}