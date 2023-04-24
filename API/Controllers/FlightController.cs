namespace API.Controllers
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    using APIRestful.Domain.Models.Request;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> logger;
        private readonly IValidator<RequestJourney> Validator;
        private readonly ISetPostFlight SetPostFlight;
        private readonly ICurrency currencyService;
        private readonly ICurrencyConvert currencyConvert;

        public FlightController(
            ILogger<FlightController> logger,
            IValidator<RequestJourney> validator,
            ISetPostFlight setPostFlight,
            ICurrency currencyService,
            ICurrencyConvert currencyConvert)
        {
            this.logger = logger;
            this.Validator = validator;
            this.SetPostFlight = setPostFlight;
            this.currencyService = currencyService;
            this.currencyConvert = currencyConvert;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var journey = new Journey()
                {
                    Origin = "MZL",
                    Destination = "BCN",
                    Price = 700,
                    Currency = "COP",
                    Flights = new List<FlightDTO>
                     {
                         new FlightDTO
                         {
                             Origin = "MZL",
                             Destination = "MDE",
                             Price = 200,
                             Transport = new Transport
                             {
                                 FlightCarrier = "CO",
                                 FlightNumber ="8001"
                             }

                         },
                         new FlightDTO
                         {
                             Origin = "MDE",
                             Destination = "BCN",
                             Price = 500,
                             Transport = new Transport
                             {
                                 FlightCarrier = "CO",
                                 FlightNumber ="8004"
                             }
                         }
                     }
                };

                var currencyValue = await this.currencyService.GetCurrency(journey.Currency);
                this.currencyConvert.ConvertCurrency(journey, currencyValue);


                return Ok(journey);

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
        public async Task<IActionResult> Get([FromBody] RequestJourney request)
        {
            try
            {
                this.logger.LogInformation("Endpoint succses Get");
                return this.Validator.Validate(request).IsValid
                    ? Ok(this.SetPostFlight.SetPostFlight(request)) :
                    BadRequest(new { message = "Validation Failed.", errors = this.Validator.Validate(request).Errors });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Endpoint Failed Get");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

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
