using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Dal.Repositories.CountryRepository
{
    /// <summary>
    /// Country repository interface
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Country collection
        /// </summary>
        IList<ICountry> CountryCollection { get; set; }
    }
}