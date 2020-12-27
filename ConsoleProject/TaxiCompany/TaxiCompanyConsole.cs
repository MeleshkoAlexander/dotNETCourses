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
            var car = new Car { Name = Ui.OutputMessage("Name"),
                Consumption = Convert.ToDouble(Ui.OutputMessage("Consumption")),
                Cost = Convert.ToDouble(Ui.OutputMessage("Cost")),
                Year = Convert.ToInt32(Ui.OutputMessage("Year")),
                StateNumber =Ui.OutputMessage("State number"),
                Vin = Ui.OutputMessage("Vin number"),
                MaxSpeed = Convert.ToDouble(Ui.OutputMessage("Max Speed"))
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
            Ui.InputMessage($"Name: {car.Name}");
            Ui.InputMessage($"Year: {car.Year}");
            Ui.InputMessage($"Cost: {car.Cost}");
            Ui.InputMessage($"State number: {car.StateNumber}");
            Ui.InputMessage($"VIN number: {car.Vin}");
            Ui.InputMessage($"Max Speed: {car.MaxSpeed}");
            Ui.InputMessage($"Consumption: {car.Consumption}");
            Ui.InputMessage(null);
        }

        public void Sort()
        {
            TaxiCompanyEconomic.Sort(_carList,(a,b)=>a.Consumption.CompareTo(b.Consumption));
        }

        public void CompanyCost()
        {
             Ui.InputMessage(TaxiCompanyEconomic.GetCompanyCost(_carList).ToString());
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