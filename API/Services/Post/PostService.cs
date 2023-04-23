using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models.Request;
using APIRestfull.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace APIResfault.Application.Services.Post
{
    public class PostService : ControllerBase, ISetPostFlight
    {

        private readonly IFlightFiltered FlightFiltered;
        private readonly ITotalCalculator TotalCalculator;
        private readonly IBuildJson BuildJson;

        public PostService(
                           IFlightFiltered flightFiltered,
                           ITotalCalculator totalCalculator,
                           IBuildJson BuildJson)
        {

            this.FlightFiltered = flightFiltered;
            this.TotalCalculator = totalCalculator;
            this.BuildJson = BuildJson;
        }

        public async Task<ActionResult> SetPostFlight(RequestJourney request)
        {
            try
            {
                var flights = await this.FlightFiltered.GetFilteredFlight(request);
                var total = this.TotalCalculator.GetTotalPriceCalcultor(flights);
                var journeyJson = this.BuildJson.BuildJourney(request, total, flights);
                return Ok(journeyJson);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message });
            }
        }

    }
}
