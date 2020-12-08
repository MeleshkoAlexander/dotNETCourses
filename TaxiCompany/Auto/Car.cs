namespace TaxiCompany.Auto
{
    public class Car: IAuto
    {
        public string Name { get; }
        public float Consumption { get; }
        public double Cost { get; }
        public int Year { get; }
        public string StatenNumber { get; }
        public string Vin { get; }

        public Car(string name,float consumption,double cost,int year,string statenNumber,string vin)
        {
            Name = name;
            Consumption = consumption;
            Cost = cost;
            Year = year;
            StatenNumber = statenNumber;
            Vin = vin;
        }
    }
}