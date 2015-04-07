namespace QuoteEngine.Objects.Domain
{
    public class Premium
    {
        public double Cost { get; set; }
        public double BasicPremium { get; set; }
        public double Risk { get; set; }

        public double GetCost()
        {
            return BasicPremium * Risk;
        }
    }
}