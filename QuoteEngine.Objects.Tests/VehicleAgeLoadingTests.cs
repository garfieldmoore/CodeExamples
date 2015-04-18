using NUnit.Framework;
using QuoteEngine.Objects.Domain;
using Shouldly;

namespace QuoteEngine.Objects.Tests
{
    public class VehicleAgeLoadingTests
    {
        [Test]
        public void Should_calulcate_low_risk_tier_one_group()
        {
            var quote = InsuranceQuote.CreateFrom("van", "mercedes");
            var premium = QuotationEngine.Calculate(quote);
            quote.Age = 36;

            premium.GetCost().ShouldBe(2000);
        }

        [Test]
        public void should_calculate_tier_2_group()
        {
            var quote = InsuranceQuote.CreateFrom("van", "mercedes");
            quote.Age = 26;
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(6000);
        }

        [Test]
        public void should_calculate_tier_3_group()
        {
            var quote = InsuranceQuote.CreateFrom("van", "mercedes");
            quote.Age = 22;
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(8000);
        }

        [Test]
        public void should_calculate_tier_4_group()
        {
            var quote = InsuranceQuote.CreateFrom("van", "mercedes");
            quote.Age = 17;
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(10000);
        }
    }
}