using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Entities.Models.Request
{
    public class RequestJourney
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
    }
}
