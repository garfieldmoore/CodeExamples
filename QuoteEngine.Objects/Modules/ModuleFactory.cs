using QuoteEngine.Objects.Rules;

namespace QuoteEngine.Objects.Modules
{
    internal class ModuleFactory
    {
        public static IInsuranceModule CreateVehicleModule()
        {
            return new InsuranceModule(()=>RuleFactory.CreateVehicleRules(), x => x.Module == "vehicle");
        }
    }
}