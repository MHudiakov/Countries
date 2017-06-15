using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Получить коллекцию стран по части имени столицы
        /// </summary>
        /// <param name="pattern">
        /// Паттерн поиска
        /// </param>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        public IList<ICountry> GetCountryCollectionByCapital(string pattern)
        {
            if (pattern == null)
                throw new ArgumentException(nameof(pattern));

            IList<ICountry> countries = CountryCollection;

            IList<ICountry> result = countries.Where(country => country.Capital.ToLower().Contains(pattern.ToLower()))
                .ToList();

            return result;
        }

        /// <summary>
        /// Получить коллекцию стран по части названия
        /// </summary>
        /// <param name="pattern">
        /// Паттерн поиска
        /// </param>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        public IList<ICountry> GetCountryCollectionByName(string pattern)
        {
            if (pattern == null)
                throw new ArgumentException(nameof(pattern));

            IList<ICountry> countries = CountryCollection;

            IList<ICountry> result = countries.Where(country => country.Name.ToLower().Contains(pattern.ToLower()))
                .ToList();

            return result;
        }
    }
}