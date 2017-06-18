using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Managers.CountriesManager
{
    /// <summary>
    /// Стратегия получения данных по странам
    /// </summary>
    public interface ICountriesManagerStrategy
    {
        /// <summary>
        /// Получить коллекцию стран
        /// </summary>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        IEnumerable<ICountry> GetCountries();
    }
}
