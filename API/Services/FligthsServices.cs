namespace APIRestfull.Services
{
    using APIRestful.Entities.Enun;
    using APIRestful.Entities.Interfaces;
    using APIRestful.Entities.Models;
    using APIRestfull.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;
    using API.Config;

    public class FligthsServices //: IFlight
    {
        //private readonly HttpClient httpClient;
        //private readonly IConfig config;

        public FligthsServices()
        {
            //this.httpClient = httpClient;
            //this.config = config;

        }

        //public async Task<Flight[]> GetAllFlightAsync()
        //{

        //    //var apiSettings = new ApiSettings();
        //    //this.config.GetSection(EnumApiResponse.ApiSettings.ToString()).Bind(apiSettings);
        //    return new Task<Flight[]>;
        //    try
        //    {
        //       // HttpResponseMessage response = this.GetConfig();
        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<Flight[]>(responseBody) ?? throw new ArgumentException("Error: responseBody is null");
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        throw new HttpRequestException("Error HTTP: " + e.Message);
        //    }
        //}
    }
}
