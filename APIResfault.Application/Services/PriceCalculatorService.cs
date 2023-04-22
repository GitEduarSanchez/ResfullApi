using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models;
using Microsoft.Extensions.Primitives;

namespace APIResfault.Application.Services
{
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
