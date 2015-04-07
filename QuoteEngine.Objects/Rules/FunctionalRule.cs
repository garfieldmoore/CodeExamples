using System;
using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Rules
{
    public class FunctionalRule : InsuranceRule
    {
        private readonly Func<InsuranceQuote, bool> _applyCondition;
        private readonly Action<Premium> _action;

        public FunctionalRule(Func<InsuranceQuote, bool> applyCondition, Action<Premium> action)
        {
            _applyCondition = applyCondition;
            _action = action;
        }

        public override Premium ApplyRule(InsuranceQuote insuranceQuote, Premium premium)
        {
            if (_applyCondition(insuranceQuote))
            {
                _action(premium);
            }

            return premium;
        }
    }
}