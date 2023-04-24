namespace APIResfault.Application.Services
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;

    public class PriceCalculatorService : ITotalCalculator
    {

        public PriceCalculatorService()
        {

        }

        public decimal GetTotalPriceCalcultor(List<Flight> flights)
        {
            return flights.Sum(flight => flight.Price);
        }

    }
}
