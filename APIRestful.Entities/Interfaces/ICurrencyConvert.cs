using APIRestful.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestful.Domain.Interfaces
{
    public interface ICurrencyConvert
    {
        Task ConvertCurrency(Journey journey, double Currency);
    }
}
