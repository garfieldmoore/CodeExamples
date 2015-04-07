using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    public abstract class InsuranceRule : IInsuranceRule
    {
        protected IInsuranceRule _nextRule;

        public void NextRule(IInsuranceRule rule)
        {
            _nextRule = rule;
        }

        public virtual Premium GetPremium(Premium premium, InsuranceQuote insuranceQuote)
        {
            premium = ApplyRule(insuranceQuote, premium);

            if (!(_nextRule == null))
            {
                premium = _nextRule.GetPremium(premium, insuranceQuote);
            }

            return premium;
        }

        public abstract Premium ApplyRule(InsuranceQuote insuranceQuote, Premium premium);
    }
}