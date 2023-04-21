
namespace APIRestful.Entities.Interfaces
{
    using APIRestful.Entities.Enun;
    using APIRestful.Entities.Models;
    using System.Threading.Tasks;


    public interface IConfig
    {
        Task<HttpResponseMessage> Get(string key, ApiSettings apiSettings);
    }
}
