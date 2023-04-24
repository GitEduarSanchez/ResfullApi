namespace APIRestfull.Services
{
    using APIRestful.Domain.Enun;
    using APIRestful.Domain.Interfaces;
    using APIRestful.Domain.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FligthsServices : IFlight
    {
        private readonly IConfig config;
        public FligthsServices(IConfig config)
        {
            this.config = config;
        }

        public async Task<List<Flight>> GetAllFlightAsync()
        {
            var apiSettings = new ApiSettings();
            try
            {
                HttpResponseMessage response = await this.config.GetAsync(EnumApiResponse.ApiSettings.ToString(), apiSettings);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Flight>>(responseBody) ?? throw new ArgumentException("Error: responseBody is null");
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Error HTTP: " + e.Message);
            }
        }
    }
}
