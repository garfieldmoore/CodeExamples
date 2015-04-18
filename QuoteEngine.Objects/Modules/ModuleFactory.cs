namespace QuoteEngine.Objects.Modules
{
    internal class ModuleFactory
    {
        public static IInsuranceModule CreateVehicleModule()
        {
            return new VehicleModule();
        }
    }
}