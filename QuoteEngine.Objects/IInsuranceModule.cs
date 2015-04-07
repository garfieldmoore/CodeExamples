using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects
{
    public interface IInsuranceModule
    {
        Premium Handle(InsuranceQuote insuranceQuote);
        bool CanHandle(InsuranceQuote insuranceQuote);
    }
}