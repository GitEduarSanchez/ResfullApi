
using APIRestful.Entities.Models;
using APIRestfull.Interfaces;
using Microsoft.AspNetCore.Mvc;
using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models.Request;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IFlight Flight;
        private readonly IFlightFiltered FlightFiltered;
        private readonly ILogger<JourneyController> logger;
        private readonly ITotalCalculator totalCalculator;
        private readonly IBuildJson buildJson;

        public JourneyController(
            IFlight flight,
            ILogger<JourneyController> logger,
            IFlightFiltered flightFiltered,
            ITotalCalculator totalCalculator,
            IBuildJson buildJson)
        {
            this.Flight = flight;
            this.logger = logger;
            this.FlightFiltered = flightFiltered;
            this.totalCalculator = totalCalculator;
            this.buildJson = buildJson;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                RequestJourney request = new RequestJourney() { DepartureStation = "MZL", ArrivalStation = "BCN" };
                List<Flight> flights = await this.FlightFiltered.GetFilteredFlight(request);
                this.logger.LogInformation("Endpoint succses Flight[]");
                return Ok(flights);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to get flights");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> GetFlightsAsync([FromBody] RequestJourney request)
        {
            var flights = await this.FlightFiltered.GetFilteredFlight(request);
            var total = this.totalCalculator.GetTotalPriceCalcultor(flights);
            var journeyJson = this.buildJson.BuildJourney(request, total, flights);
            this.logger.LogInformation("Endpoint succses Flight[]");
            return Ok(journeyJson);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
