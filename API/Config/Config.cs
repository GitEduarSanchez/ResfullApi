using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models;

namespace API.Config
{
    public class Config
    {
        private readonly IConfig config;
        private readonly HttpClient httpClient;
        public Config(IConfig config, HttpClient httpClient)
        {
            this.config = config;
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetConfig(string key, ApiSettings apapiSettings)
        {
            this.config.GetSection(key).Bind(apapiSettings);
            return await this.httpClient.GetAsync(apapiSettings.BaseUrl + apapiSettings.Resources.Flights);
        }
    }
}
