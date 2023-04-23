using Microsoft.AspNetCore.Mvc;
using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models.Request;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;
using APIRestful.Entities.Models;
using APIRestful.Entities.Enun;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly ILogger<JourneyController> logger;
        private readonly IValidator<RequestJourney> Validator;
        private readonly ISetPostFlight SetPostFlight;

        public JourneyController(
            ILogger<JourneyController> logger,
            IValidator<RequestJourney> validator,
            ISetPostFlight setPostFlight)
        {
            this.logger = logger;
            this.Validator = validator;
            this.SetPostFlight = setPostFlight;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                return Ok();
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

        /// <summary>
        /// GetFlightsAsync
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Journey))]
        public async Task<IActionResult> GetFlightsAsync([FromBody] RequestJourney request)
        {
            try
            {
                this.logger.LogInformation("Endpoint succses GetFlightsAsync");
                return this.Validator.Validate(request).IsValid
                    ? Ok(this.SetPostFlight.SetPostFlight(request)) :
                    BadRequest(new { message = "Validation Failed.", errors = this.Validator.Validate(request).Errors });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Endpoint Failed GetFlightsAsync");
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
