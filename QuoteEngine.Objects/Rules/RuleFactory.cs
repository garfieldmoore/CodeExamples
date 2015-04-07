using System.Reflection;
using QuoteEngine.Objects.Modules;

namespace QuoteEngine.Objects.Rules
{
    internal class RuleFactory
    {
        public static IInsuranceRule CreateVehicleRules()
        {
            var builder = new VehicleModuleRulesBuilder();
            builder.WithCarRule().WithVanRule().WithAudiRule().WithMercedesRule();

            return builder.Build();
        }
    }
}