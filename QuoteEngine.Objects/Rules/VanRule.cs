using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    internal class VanRule : InsuranceRule
    {
        public override Premium ApplyRule(InsuranceQuote insuranceQuote, Premium premium)
        {
            if (insuranceQuote.Type == "van")
            {
                premium.BasicPremium = 1000;
            }
            return premium;
        }
    }
}