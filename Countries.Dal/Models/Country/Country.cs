using System.Collections.Generic;
using Countries.Dal.Models.Currency;

namespace Countries.Dal.Models.Country
{
    /// <summary>
    /// Модель страны
    /// </summary>
    public sealed class Country : ICountry
    {
        public string Name { get; set; }
        
        public string Capital { get; set; }
        
        public IEnumerable<ICurrency> CurrencyCollection { get; set; }
        public void Update(ICountry country)
        {
            Name = country.Name;
            Capital = country.Capital;
            CurrencyCollection = country.CurrencyCollection;
        }
    }
}
