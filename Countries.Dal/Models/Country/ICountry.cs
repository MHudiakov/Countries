using System.Collections.Generic;
using Countries.Dal.Models.Currency;

namespace Countries.Dal.Models.Country
{
    /// <summary>
    /// Country model interface
    /// </summary>
    public interface ICountry
    {
        string Name { get; set; }

        string Capital { get; set; }

        IEnumerable<ICurrency> CurrencyCollection { get; set; }

        void Update(ICountry country);
    }
}
