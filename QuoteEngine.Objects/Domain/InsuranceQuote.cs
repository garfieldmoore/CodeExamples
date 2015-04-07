namespace QuoteEngine.Objects.Domain
{
    public class InsuranceQuote
    {
        public static InsuranceQuote CreateFrom(string type, string manufacturer)
        {
            return new InsuranceQuote(){Manufacturer=manufacturer, Type = type, Module = "vehicle"};
        }

        public string Module { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
    }
}