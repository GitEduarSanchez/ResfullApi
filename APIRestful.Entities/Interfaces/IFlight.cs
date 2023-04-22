using APIRestful.Entities.Models;

namespace APIRestfull.Interfaces
{
    public interface IFlight
    {
        Task<List<Flight>> GetAllFlightAsync();
    }
}
