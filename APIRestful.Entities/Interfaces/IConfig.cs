
namespace APIRestful.Domain.Interfaces
{
    using APIRestful.Domain.Models;
    using System.Threading.Tasks;

    public interface IConfig
    {
        Task<HttpResponseMessage> GetAsync(string key, ApiSettings apiSettings);
    }
}
