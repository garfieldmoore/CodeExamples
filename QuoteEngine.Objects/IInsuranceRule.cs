using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects
{
    public interface IInsuranceRule
    {   
        Premium GetPremium(Premium premium, InsuranceQuote insuranceQuote);
    }
}