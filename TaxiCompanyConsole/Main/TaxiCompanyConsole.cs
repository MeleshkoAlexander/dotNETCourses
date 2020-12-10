using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaxiCompany.Auto;
using TaxiCompany.TaxiCompany;
using TaxiCompanyConsole.UI;

namespace TaxiCompanyConsole
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
            var car = new Car { Name = UI.Ui.OutputMessage("Name"),
                Consumption = Convert.ToDouble(Ui.OutputMessage("Consumption")),
                Cost = Convert.ToDouble(UI.Ui.OutputMessage("Cost")),
                Year = Convert.ToInt32(UI.Ui.OutputMessage("Year")),
                StateNumber =UI.Ui.OutputMessage("State number"),
                Vin = UI.Ui.OutputMessage("Vin number"),
                MaxSpeed = Convert.ToDouble(UI.Ui.OutputMessage("Max Speed"))
            };
            _taxiCarCompany.Add(car);
            _taxiCarCompany.Save();
            Console.Clear();
        }

        public void Show()
        {
            foreach (var car in _carList)
            {
                Ui.InputMessage($"Name:{car.Name}");
                Ui.InputMessage($"Year:{car.Year}");
                Ui.InputMessage($"Cost:{car.Cost}");
                Ui.InputMessage($"State number:{car.StateNumber}");
                Ui.InputMessage($"VIN number:{car.Vin}");
                Ui.InputMessage($"Max Speed:{car.MaxSpeed}");
                Ui.InputMessage($"Consumption:{car.Consumption}");
            }
        }

        public void Sort()
        {
            TaxiCompanyEconomic.Sort(_carList,(a,b)=>a.Consumption.CompareTo(b.Consumption));
        }
    }
}