﻿using APIRestful.Entities.Enun;
using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models;
using APIRestful.Entities.Models.Request;
using APIRestfull.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Windows.Markup;

namespace APIResfault.Application.Services
{
    public class BuildJsonService : IBuildJson
    {
        public BuildJsonService()
        {
        }
        public string BuildJourney(RequestJourney request, decimal total, List<Flight> flights)
        {

            var flightDTOList = flights.Select(flight => new FlightDTO
            {
                Origin = flight.DepartureStation ?? string.Empty,
                Destination = flight.ArrivalStation ?? string.Empty,
                Price = (double)flight.Price,
                Transport = new Transport
                {
                    FlightCarrier = flight.FlightCarrier ?? string.Empty,
                    FlightNumber = flight.FlightNumber ?? string.Empty,
                }
            }).ToList();

            var journey = new Journey
            {
                Origin = request.DepartureStation ?? string.Empty,
                Destination = request.ArrivalStation ?? string.Empty,
                Price = (double)total,
                Flights = flightDTOList ?? new List<FlightDTO>()
            };

            var JourneyResponse = new JourneyResponse
            {
                Journey = journey
            };
            return JsonConvert.SerializeObject(JourneyResponse, Formatting.Indented);
        }

    }
}

