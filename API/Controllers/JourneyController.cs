using API.Interfaces;
using APIRestful.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IFlight Flight;
        private readonly ILogger<JourneyController> logger;

        public JourneyController(IFlight flight, ILogger<JourneyController> logger)
        {
            this.Flight = flight;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Flight[] flights = await this.Flight.GetAllFlightAsync();
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
        public void Post([FromBody] string value)
        {
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
