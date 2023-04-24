namespace APIResfault.Application.Services.Filter
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    using APIRestful.Domain.Models.Request;

    public class FilterFlightServices : IFlightFiltered
    {
        private readonly IFlight Flight;

        public FilterFlightServices(IFlight flight)
        {
            this.Flight = flight;

        }

        public async Task<List<Flight>> GetFilteredFlight(RequestJourney request)
        {
            var responseModel = await this.Flight.GetAllFlightAsync();
            var filteredFlights = responseModel
              .Where(flight1 => flight1.DepartureStation == request.DepartureStation)
              .Join(
                  responseModel.Where(flight2 => flight2.ArrivalStation == request.ArrivalStation),
                  flight1 => flight1.ArrivalStation,
                  flight2 => flight2.DepartureStation,
                  (flight1, flight2) => new List<Flight> { flight1, flight2 }
              )
              .SelectMany(x => x)
              .ToList();

            return filteredFlights;
        }
    }
}
