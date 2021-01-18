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
            var car = new Car { Name = IocStatic.OutputMessage("Name"),
                Consumption = Convert.ToDouble(IocStatic.OutputMessage("Consumption")),
                Cost = Convert.ToDouble(IocStatic.OutputMessage("Cost")),
                Year = Convert.ToInt32(IocStatic.OutputMessage("Year")),
                StateNumber =IocStatic.OutputMessage("State number"),
                Vin = IocStatic.OutputMessage("Vin number"),
                MaxSpeed = Convert.ToDouble(IocStatic.OutputMessage("Max Speed"))
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
            IocStatic.InputMessage($"Name: {car.Name}");
            IocStatic.InputMessage($"Year: {car.Year}");
            IocStatic.InputMessage($"Cost: {car.Cost}");
            IocStatic.InputMessage($"State number: {car.StateNumber}");
            IocStatic.InputMessage($"VIN number: {car.Vin}");
            IocStatic.InputMessage($"Max Speed: {car.MaxSpeed}");
            IocStatic.InputMessage($"Consumption: {car.Consumption}");
            IocStatic.InputMessage(null);
        }

        public void Sort()
        {
            TaxiCompanyEconomic.Sort(_carList,(a,b)=>a.Consumption.CompareTo(b.Consumption));
        }

        public void CompanyCost()
        {
             IocStatic.InputMessage(TaxiCompanyEconomic.GetCompanyCost(_carList).ToString());
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