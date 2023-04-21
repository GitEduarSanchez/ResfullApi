
namespace APIRestful.Entities.Interfaces
{
    using APIRestful.Entities.Models;
    using Microsoft.Extensions.Configuration;

    public interface IConfig
    {
        Task<HttpResponseMessage> GetConfig(string key, ApiSettings apiSettings);
    }
}
