namespace APIRestful.Domain.Interfaces
{
    using APIRestful.Domain.Models;

    public interface ITotalCalculator
    {
        decimal GetTotalPriceCalcultor(List<Flight> flights);
    }
}
