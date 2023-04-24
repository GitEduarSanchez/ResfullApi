


namespace API.Controllers
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly ILogger<CurrencyController> logger;
        private readonly ICurrencyConvert currencyConvert;
        private readonly ICurrency currencyService;
        private readonly ICurrencyType currencyType;
        public CurrencyController(
                ICurrencyConvert currencyConvert,
                ICurrency currencyService,
                ICurrencyType currencyType)
        {
            this.currencyConvert = currencyConvert;
            this.currencyService = currencyService;
            this.currencyType = currencyType;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Journey journey)
        {
            try
            {
                var currencyTypes = this.currencyType.GetCurrencies();
                if (!currencyTypes.Contains(journey.Currency))
                {
                    return BadRequest("No Soported currency");
                }

                var currencyValue = await this.currencyService.GetCurrency(journey.Currency);
                this.currencyConvert.ConvertCurrency(journey, currencyValue);
                return Ok(journey);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
