namespace APIRestfull.Services
{
    using APIRestful.Entities.Enun;
    using APIRestful.Entities.Interfaces;
    using APIRestful.Entities.Models;
    using APIRestfull.Interfaces;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FligthsServices : IFlight
    {
        private readonly IConfig config;
        public FligthsServices(IConfig config)
        {
            this.config = config;
        }

        public async Task<Flight[]> GetAllFlightAsync()
        {
            var apiSettings = new ApiSettings();
            try
            {
                HttpResponseMessage response = await this.config.Get(EnumApiResponse.ApiSettings.ToString(), apiSettings);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Flight[]>(responseBody) ?? throw new ArgumentException("Error: responseBody is null");
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Error HTTP: " + e.Message);
            }
        }
    }
}
