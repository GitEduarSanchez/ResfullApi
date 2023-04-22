using APIRestful.Entities.Models.Request;
using APIRestful.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Entities.Interfaces
{
    public interface IBuildJson
    {
        string BuildJourney(RequestJourney request, decimal total, List<Flight> flights);
    }
}
