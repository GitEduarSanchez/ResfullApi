using Microsoft.Extensions.Configuration;

namespace APIRestful.Domain.Interfaces
{
    public interface IHttpClient
    {
        IConfigurationSection GetSection(string key);
    }
}
