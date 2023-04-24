using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Domain.Models.Currency
{
    public class ExchangeRateResponse
    {
        public ExchangeRates Result { get; set; }
        public string Status { get; set; }
    }
}
