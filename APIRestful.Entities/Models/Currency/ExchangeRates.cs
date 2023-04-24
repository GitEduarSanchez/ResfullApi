namespace APIRestful.Domain.Models.Currency
{
    public class ExchangeRates
    {
        public string Updated { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public decimal Value { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
