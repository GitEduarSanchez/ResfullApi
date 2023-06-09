﻿namespace APIRestfull.Services
{
    using APIRestful.Entities.Enun;
    using APIRestful.Entities.Models;
    using APIRestfull.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Runtime;
    using System.Threading.Tasks;

    public class FligthsServices : IFlight
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public FligthsServices(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;

        }

        public async Task<Flight[]> GetAllFlightAsync()
        {

            var apiSettings = new ApiSettings();
            this.config.GetSection(EnumApiResponse.ApiSettings.ToString()).Bind(apiSettings);
           ¿

            try
            {
                HttpResponseMessage response = await this.httpClient.GetAsync(apiSettings.BaseUrl + apiSettings.Resources.Flights);
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
