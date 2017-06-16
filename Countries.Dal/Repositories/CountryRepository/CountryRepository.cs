using System.Collections.Generic;
using Countries.Dal.Models.Country;

namespace Countries.Dal.Repositories.CountryRepository
{
    /// <summary>
    /// Репозиторий стран
    /// </summary>
    public sealed class CountryRepository : ICountryRepository
    {
        /// <summary>
        /// Получить всю коллекцию стран
        /// </summary>
        public IList<ICountry> CountryCollection { get; set; }
    }
}