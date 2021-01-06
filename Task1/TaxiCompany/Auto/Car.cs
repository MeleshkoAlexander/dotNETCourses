using System;

namespace TaxiCompany.Auto
{
    [Serializable]
    public class Car: IAuto, ICloneable
    {
        public string Name { get; set; }
        public double Consumption { get; set; }
        public double Cost { get; set; }
        public int Year { get; set; }
        public string StateNumber { get; set; }
        public string Vin { get; set; }
        
        public double MaxSpeed { get; set; }
        
        public Car() // Default constructor without parameters
        {}
        public Car(string name,double consumption,double cost,int year,string statenNumber,string vin,double maxSpeed)
        {
            Name = name;
            Consumption = consumption;
            Cost = cost;
            Year = year;
            StateNumber = statenNumber;
            Vin = vin;
            MaxSpeed = maxSpeed;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}