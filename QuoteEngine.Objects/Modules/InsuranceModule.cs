using System;
using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Modules
{
    public class InsuranceModule : IInsuranceModule
    {
        private readonly Func<InsuranceQuote, bool> _canHandle;
        protected IInsuranceRule Rule;

        public InsuranceModule(Func<IInsuranceRule> ruleProvider, Func<InsuranceQuote, bool> canHandle)
        {
            Rule = ruleProvider();
            _canHandle = canHandle;
        }

        public virtual bool CanHandle(InsuranceQuote insuranceQuote)
        {
            return _canHandle(insuranceQuote);
        }

        public virtual Premium Handle(InsuranceQuote insuranceQuote)
        {
            if (!CanHandle(insuranceQuote))
                return null;

            var premium = new Premium();
            premium = Rule.GetPremium(premium, insuranceQuote);

            return premium;
        }
    }
}