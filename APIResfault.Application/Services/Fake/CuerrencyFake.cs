namespace API.Services.Currency.Fake
{
    using APIRestful.Domain.Enun;
    using APIRestful.Domain.Interfaces;
    using Nest;
    using System.Collections.Generic;

    public class CuerrencyTypeFake : ICurrencyType
    {
        public List<string> GetCurrencies()
        {
            return new List<string>
            {
                CurrencyType.EUR.ToString(),
                CurrencyType.COP.ToString(),
            };
        }
    }

}
