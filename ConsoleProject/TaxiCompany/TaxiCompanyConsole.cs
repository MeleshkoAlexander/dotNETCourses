using System;
using System.Collections.Generic;
using TaxiCompany.Auto;
using TaxiCompany.TaxiCompany;

namespace ConsoleProject.TaxiCompany
{
    public class TaxiCompanyConsole
    {
        private readonly TaxiCompany<Car> _taxiCarCompany;
        private readonly List<Car> _carList;
        public TaxiCompanyConsole()
        {
            _taxiCarCompany = new TaxiCompany<Car>();
            _taxiCarCompany.Load();
            _carList = _taxiCarCompany.GetCopy();
        }

        public void Create()
        {
            var car = new Car { Name = IOC.OutputMessage("Name"),
                Consumption = Convert.ToDouble(IOC.OutputMessage("Consumption")),
                Cost = Convert.ToDouble(IOC.OutputMessage("Cost")),
                Year = Convert.ToInt32(IOC.OutputMessage("Year")),
                StateNumber =IOC.OutputMessage("State number"),
                Vin = IOC.OutputMessage("Vin number"),
                MaxSpeed = Convert.ToDouble(IOC.OutputMessage("Max Speed"))
            };
            _taxiCarCompany.Add(car);
            _taxiCarCompany.Save();
            Console.Clear();
        }

        public void ShowList()
        {
            foreach (var car in _carList)
            {
                Show(car);
            }
        }

        private static void Show<TAutoType>(TAutoType car) where TAutoType : IAuto
        {
            IOC.InputMessage($"Name: {car.Name}");
            IOC.InputMessage($"Year: {car.Year}");
            IOC.InputMessage($"Cost: {car.Cost}");
            IOC.InputMessage($"State number: {car.StateNumber}");
            IOC.InputMessage($"VIN number: {car.Vin}");
            IOC.InputMessage($"Max Speed: {car.MaxSpeed}");
            IOC.InputMessage($"Consumption: {car.Consumption}");
            IOC.InputMessage(null);
        }

        public void Sort()
        {
            TaxiCompanyEconomic.Sort(_carList,(a,b)=>a.Consumption.CompareTo(b.Consumption));
        }

        public void CompanyCost()
        {
             IOC.InputMessage(TaxiCompanyEconomic.GetCompanyCost(_carList).ToString());
        }

        public void SpeedSelection(double minLimit,double maxLimit)
        {
            var carList = TaxiCompanySelection.FindBySpeed(_carList,minLimit,maxLimit);
            foreach (var car in carList)
            {
                Show(car);
            }
        }
    }
}