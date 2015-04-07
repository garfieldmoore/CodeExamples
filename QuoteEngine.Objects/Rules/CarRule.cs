using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    internal class CarRule : InsuranceRule
    {
        public override Premium ApplyRule(InsuranceQuote insuranceQuote, Premium premium)
        {
            if (insuranceQuote.Type == "car")
            {
                premium.BasicPremium = 800;
            }
            return premium;
        }

    }
}