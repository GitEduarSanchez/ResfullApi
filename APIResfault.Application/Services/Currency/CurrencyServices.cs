namespace APIResfault.Application.Services.Currency
{
    using APIRestful.Domain.Enun;
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    using APIRestful.Domain.Models.Currency;
    using Newtonsoft.Json;

    public class CurrencyServices : ICurrency
    {
        private readonly ICurrencyValue config;
        public CurrencyServices(ICurrencyValue config)
        {
            this.config = config;
        }
        public async Task<double> GetCurrency(string currencyType)
        {
            var apiSettings = new ApiSettings();

            HttpResponseMessage response = await this.config.GetAsync(
                EnumApiResponse.ApiSettings.ToString(),
                apiSettings,
                currencyType);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateResponse>(responseJson) ??
                throw new ArgumentException("Error: responseJson is null");
            return (double)exchangeRate.Result.Value;
        }
    }
}
