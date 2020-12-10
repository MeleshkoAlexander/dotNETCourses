using System;
using TaxiCompany.Auto;

namespace TaxiCompany.Factory
{
    public abstract class AutoCreator
    {
        public IAuto GetAuto()
        {
            return Create();
        }

        protected abstract IAuto Create();
    }
}