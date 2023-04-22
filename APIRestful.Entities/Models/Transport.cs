using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Entities.Models
{
    public class Transport
    {
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
    }
}
