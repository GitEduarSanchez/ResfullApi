using APIRestful.Domain.Models;
using APIRestful.Domain.Models.Request;

namespace APIRestful.Domain.Interfaces
{
    public interface IFlightFiltered
    {
        Task<List<Flight>> GetFilteredFlight(RequestJourney request);
    }
}
