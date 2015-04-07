using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    internal class MercedesManufacturerRule : InsuranceRule
    {       
        public override Premium ApplyRule(InsuranceQuote insuranceQuote, Premium premium)
        {
            if (insuranceQuote.Manufacturer == "Mercedes")
            {
                premium.Risk = 2;
            }
            return premium;
        }
    }
}