using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Dal.Repositories.CountryRepository
{
    /// <summary>
    /// Country repository
    /// </summary>
    public sealed class CountryRepository : ICountryRepository
    {
        /// <summary>
        /// Get country collection
        /// </summary>
        public IList<ICountry> CountryCollection { get; set; }
    }
}