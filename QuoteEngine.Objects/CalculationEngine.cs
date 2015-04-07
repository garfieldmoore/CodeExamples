using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects
{
    public class CalculationEngine
    {
        private IList<IInsuranceModule> _modules;

        public CalculationEngineErrorHandler ErrorHandler { get; set; }

        public CalculationEngine(IList<IInsuranceModule> modules)
        {
            _modules = modules;
            ErrorHandler=new CalculationEngineErrorHandler();
        }

        public Premium CalculatePremium(InsuranceQuote insuranceQuote)
        {
            Contract.Requires<ArgumentNullException>(insuranceQuote  !=null);

            bool handled = false;
            Premium premium=null;
            
            foreach (var module in _modules)
            {
                if (module.CanHandle(insuranceQuote))
                {
                    premium = module.Handle(insuranceQuote);
                    handled = true;
                    break;
                }
            }

            if (!handled)
            {
               ErrorHandler.RaiseUnknownModuleError(insuranceQuote.Module);
            }

            return premium;
        }

        public class CalculationEngineErrorHandler
        {
            public virtual void RaiseUnknownModuleError(string module)
            {
                throw new Exception(string.Format("Unknown module {0}", module));
            }
        }
    }
}