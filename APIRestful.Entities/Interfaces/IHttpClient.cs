namespace API.Interfaces
{
    public interface IHttpClient
    {
        IConfigurationSection GetSection(string key);
    }
}
