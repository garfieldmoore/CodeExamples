using System.Collections.Generic;

namespace QuoteEngine.Objects.Rules
{
    internal class VehicleModuleRulesBuilder
    {
        private IList<FunctionalRule> rules;

        public VehicleModuleRulesBuilder()
        {
            rules = new List<FunctionalRule>();
        }

        public VehicleModuleRulesBuilder WithCarRule()
        {
            rules.Add(new FunctionalRule(x => x.Type == "car", x => x.BasicPremium = 800));

            return this;
        }

        public VehicleModuleRulesBuilder WithVanRule()
        {
            rules.Add(new FunctionalRule(x => x.Type == "van", x => x.BasicPremium = 1000));

            return this;
        }

        public VehicleModuleRulesBuilder WithMercedesRule()
        {
            rules.Add(new FunctionalRule(x => x.Manufacturer.ToLower() == "mercedes", x => x.Risk = 2));

            return this;
        }

        public VehicleModuleRulesBuilder WithAudiRule()
        {
            rules.Add(new FunctionalRule(x => x.Manufacturer == "Audi", x => x.Risk = 1.5));

            return this;
        }

        public IInsuranceRule Build()
        {
            var target = rules[0];
            for (int i =0;i<=rules.Count-1; i++)
            {
                target.NextRule(rules[i]);
                target = rules[i];

            }

            return rules[0];
        }
    }
}