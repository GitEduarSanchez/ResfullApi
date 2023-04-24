
namespace APIRestful.Domain.Interfaces
{
    using APIRestful.Domain.Models;
    using APIRestful.Domain.Models.Request;

    public interface IBuildJson
    {
        string BuildJourney(RequestJourney request, decimal total, List<Flight> flights);
    }
}
