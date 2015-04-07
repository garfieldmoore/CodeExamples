using System.Collections.Generic;
using QuoteEngine.Objects.Modules;

namespace QuoteEngine.Objects.Domain
{
    public class QuotationEngine
    {
        private static CalculationEngine _calcualtionEngine;
     
        public static Premium Calculate(InsuranceQuote insuranceQuote)
        {
            var modules = new List<IInsuranceModule>();

            modules.Add(ModuleFactory.CreateVehicleModule());

            _calcualtionEngine = new CalculationEngine(modules);

            var premium = _calcualtionEngine.CalculatePremium(insuranceQuote);
            
            return premium;
        }
    }
}