namespace APIRestful.Domain.Interfaces
{
    public interface ICurrency
    {
        Task<double> GetCurrency(string currencyType);
    }
}
