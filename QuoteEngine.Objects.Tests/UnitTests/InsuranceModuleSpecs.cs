using NSubstitute;
using NUnit.Framework;
using QuoteEngine.Objects.Domain;
using QuoteEngine.Objects.Modules;
using Shouldly;

namespace QuoteEngine.Objects.Tests.UnitTests
{
    public class InsuranceModuleSpecs
    {
        [Test]
        public void Should_invoke_get_premium_if_canhandle()
        {
            var rule = Substitute.For<IInsuranceRule>();
            var module = new InsuranceModule(() => rule, (x) => true);
            
            module.Handle(new InsuranceQuote());

            rule.Received().GetPremium(Arg.Any<Premium>(),Arg.Any<InsuranceQuote>());
        }

        [Test]
        public void Should_not_invoke_get_premium_if_rule_cannot_handle_quote()
        {
            var rule = Substitute.For<IInsuranceRule>();
            var module = new InsuranceModule(() => rule, (x) => false);
            module.CanHandle(new InsuranceQuote());

            rule.DidNotReceive().GetPremium(Arg.Any<Premium>(), Arg.Any<InsuranceQuote>());
        }

        [Test]
        public void Should_return_null_if_cannot_handle()
        {
            var rule = Substitute.For<IInsuranceRule>();
            var module = new InsuranceModule(() => rule, (x) => false);
            rule.GetPremium(Arg.Any<Premium>(), Arg.Any<InsuranceQuote>()).Returns(new Premium());
            var result = module.Handle(new InsuranceQuote());

            result.ShouldBe(null);
        }
    }
}