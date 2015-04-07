using NUnit.Framework;
using QuoteEngine.Objects.Domain;
using Shouldly;

namespace QuoteEngine.Objects.Tests
{
    public class AcceptanceTests
    {
        [Test]
        public void Should_calculate_mercedes_van()
        {
            var quote = InsuranceQuote.CreateFrom("van", "Mercedes");
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(2000);
        }

        [Test]
        public void Should_calcualate_mercedes_car()
        {
            var quote = InsuranceQuote.CreateFrom("car", "Mercedes");
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(1600);
        }

        [Test]
        public void Should_calcualate_audi_car()
        {
            var quote = InsuranceQuote.CreateFrom("car", "Audi");
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(1200);
        }

        [Test]
        public void Should_calcualate_audi_van()
        {
            var quote = InsuranceQuote.CreateFrom("van", "Audi");
            var premium = QuotationEngine.Calculate(quote);

            premium.GetCost().ShouldBe(1500);
        }
//
//        [Test]
//        public void Should_calculate_mercedes_tank()
//        {
//            var quote = InsuranceQuote.CreateFrom("tank", "Mercedes");
//
//            var premium = QuotationEngine.Calculate(quote);
//
//            premium.GetCost().ShouldBe(50000);
//        }
    }
}
