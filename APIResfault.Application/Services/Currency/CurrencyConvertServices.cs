using APIRestful.Domain.Interfaces;
using APIRestful.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIResfault.Application.Services.Currency
{
    public class CurrencyConvertServices : ICurrencyConvert
    {

        public CurrencyConvertServices()
        {

        }

        public async Task ConvertCurrency(Journey journey, double Currency)
        {

            journey.Price *= Currency;
            journey.Flights.ForEach(flight =>
            {
                flight.Price *= Currency;
            });

        }
    }
}
