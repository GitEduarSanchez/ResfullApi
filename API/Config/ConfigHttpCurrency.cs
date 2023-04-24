namespace API.Config
{
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    public class ConfigHttpCurrency : ICurrencyValue
    {
        private readonly IConfiguration config;
        private readonly HttpClient httpClient;
        public ConfigHttpCurrency(IConfiguration config, HttpClient httpClient)
        {
            this.config = config;
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAsync(string key, ApiSettings apiSettings, string currencyType)
        {
            this.config.GetSection(key).Bind(apiSettings);
            var prueba = apiSettings.BaseUrlCurrency + currencyType + apiSettings.Resources.Currency + apiSettings.Apikey;
            return await this.httpClient.GetAsync(apiSettings.BaseUrlCurrency + currencyType + apiSettings.Resources.Currency + apiSettings.Apikey);
        }
    }
}


