using System;

namespace TaxiCompany.Auto
{
    [Serializable]
    public class Car: IAuto, ICloneable
    {
        public string Name { get; }
        public double Consumption { get; }
        public double Cost { get; }
        public int Year { get; }
        public string StatenNumber { get; }
        public string Vin { get; }
        
        public double MaxSpeed { get; }
        
        public Car() // Default constructor without parameters
        {}
        public Car(string name,float consumption,double cost,int year,string statenNumber,string vin,double maxSpeed)
        {
            Name = name;
            Consumption = consumption;
            Cost = cost;
            Year = year;
            StatenNumber = statenNumber;
            Vin = vin;
            MaxSpeed = maxSpeed;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}