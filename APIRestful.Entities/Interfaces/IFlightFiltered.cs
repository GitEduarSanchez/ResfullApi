using APIRestful.Entities.Models;
using APIRestful.Entities.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Entities.Interfaces
{
    public interface IFlightFiltered
    {
        Task<List<Flight>> GetFilteredFlight(RequestJourney request);
    }
}
