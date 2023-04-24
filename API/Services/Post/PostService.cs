namespace APIResfault.Application.Services.Post
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models.Request;
    using Microsoft.AspNetCore.Mvc;

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
