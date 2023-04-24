namespace APIRestful.Domain.Interfaces
{
    using APIRestful.Domain.Models;
    public interface IFlight
    {
        Task<List<Flight>> GetAllFlightAsync();
    }
}
