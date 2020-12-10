using TaxiCompany.Auto;

namespace TaxiCompany.Factory
{
    public class CarCreator: AutoCreator
    {
        protected override IAuto Create()
        {
            return new Car();
        }
    }
}