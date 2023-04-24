using APIRestful.Domain.Interfaces;
using APIRestful.Domain.Models;

namespace API.Config
{
    public class Config : IConfig
    {
        private readonly IConfiguration config;
        private readonly HttpClient httpClient;
        public Config(IConfiguration config, HttpClient httpClient)
        {
            this.config = config;
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAsync(string key, ApiSettings apiSettings)
        {
            this.config.GetSection(key).Bind(apiSettings);
            return await this.httpClient.GetAsync(apiSettings.BaseUrlFlight + apiSettings.Resources.Flights);
        }
    }
}

