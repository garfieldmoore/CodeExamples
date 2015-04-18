using QuoteEngine.Objects.Domain;
using QuoteEngine.Objects.Rules;

namespace QuoteEngine.Objects.Modules
{
    internal class VehicleModule : IInsuranceModule
    {
        private InsuranceModule _module;

        public VehicleModule()
        {
            _module = new InsuranceModule(() => RuleFactory.CreateVehicleRules(), x => x.Module == "vehicle");
        }

        public Premium Handle(InsuranceQuote insuranceQuote)
        {
            if (!CanHandle(insuranceQuote))
            {
                return null;
            }

            var premium = _module.Handle(insuranceQuote);
            if (insuranceQuote.Age > 25 && insuranceQuote.Age < 36)
            {
                premium.Risk*=3;
            }

            if (insuranceQuote.Age > 21 && insuranceQuote.Age < 26)
            {
                premium.Risk *= 4;
            }

            if (insuranceQuote.Age > 16 && insuranceQuote.Age < 22)
            {
                premium.Risk *= 5;
            }
            return premium;
        }

        public bool CanHandle(InsuranceQuote insuranceQuote)
        {
            return _module.CanHandle(insuranceQuote);
        }
    }
}