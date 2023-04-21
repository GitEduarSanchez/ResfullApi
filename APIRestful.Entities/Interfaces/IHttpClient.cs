using Microsoft.Extensions.Configuration;

namespace APIRestfull.Interfaces
{
    public interface IHttpClient
    {
        IConfigurationSection GetSection(string key);
    }
}
