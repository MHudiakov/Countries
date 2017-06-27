using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Managers.CountriesManager
{
    /// <summary>
    /// O btain data for countries strategy
    /// </summary>
    public interface ICountriesManagerStrategy
    {
        /// <summary>
        /// Get countries
        /// </summary>
        /// <returns>
        /// Countries collection
        /// </returns>
        IEnumerable<ICountry> GetCountries();
    }
}
