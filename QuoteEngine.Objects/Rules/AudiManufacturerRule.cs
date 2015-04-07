using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    internal class AudiManufacturerRule : InsuranceRule
    {
        public override Premium ApplyRule(InsuranceQuote insuranceQuote, Premium factor)
        {
            if (insuranceQuote.Manufacturer == "Audi")
            {
                factor.Risk = 1.5;
            }

            return factor;
        }
    }
}