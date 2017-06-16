using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Dal.Repositories.CountryRepository
{
    /// <summary>
    /// Интерфейс репозитория стран
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Коллекция стран
        /// </summary>
        IList<ICountry> CountryCollection { get; set; }
    }
}