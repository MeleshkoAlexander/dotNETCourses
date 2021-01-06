using System;

namespace TaxiCompany.Auto
{
    public interface IAuto
    {
        string Name { get; }
        double Consumption { get; }
        double Cost { get; }
        int Year { get; }
        string StateNumber { get; }
        string Vin { get; }
        double MaxSpeed { get; }
    }
}