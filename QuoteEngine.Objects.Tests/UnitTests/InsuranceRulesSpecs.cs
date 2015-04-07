using System;
using NSubstitute;
using NUnit.Framework;
using QuoteEngine.Objects.Domain;
using QuoteEngine.Objects.Rules;
using Shouldly;

namespace QuoteEngine.Objects.Tests.UnitTests
{
    public class InsuranceRulesSpecs
    {
        private int _invoked;
        private FunctionalRule _rule;

        [Test]
        public void Should_not_apply_rule_when_apply_condition_untrue()
        {
            GivenARule(x=>false);

            _rule.GetPremium(new Premium(), new InsuranceQuote());
            _invoked.ShouldBe(0);
        }

        [Test]
        public void Should_apply_rule_when_apply_condition_true()
        {
            GivenARule((x) => true);

            _rule.GetPremium(new Premium(), new InsuranceQuote());
            _invoked.ShouldBe(1);
        }

        [Test] 
        public void Should_apply_next_rule_when_rule_not_applied()
        {
            GivenARule(x=>false);

            var nextRule = Substitute.For<IInsuranceRule>();
            _rule.NextRule(nextRule);

            _rule.GetPremium(new Premium(), new InsuranceQuote());

            nextRule.Received().GetPremium(Arg.Any<Premium>(), Arg.Any<InsuranceQuote>());
        }

        [Test]
        public void Should_apply_next_rule_when_rule_applied()
        {
            GivenARule(x => true);

            var nextRule = Substitute.For<IInsuranceRule>();
            _rule.NextRule(nextRule);

            _rule.GetPremium(new Premium(), new InsuranceQuote());

            nextRule.Received().GetPremium(Arg.Any<Premium>(), Arg.Any<InsuranceQuote>());
        }

        private void GivenARule(Func<object, bool> func)
        {
            _invoked = 0;
            _rule = new FunctionalRule(func, Invoked);
        }

        private void Invoked(Premium obj)
        {
            _invoked++;
        }     
    }
}