using APIRestful.Entities.Models;

namespace API.Interfaces
{
    public interface IFlight
    {
        Task<Flight[]> GetAllFlightAsync();
    }
}
