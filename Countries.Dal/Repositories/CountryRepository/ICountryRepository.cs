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

        /// <summary>
        /// Получить коллекцию стран по части имени столицы
        /// </summary>
        /// <param name="pattern">
        /// Паттерн поиска
        /// </param>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        IList<ICountry> GetCountryCollectionByCapital(string pattern);

        /// <summary>
        /// Получить коллекцию стран по части названия
        /// </summary>
        /// <param name="pattern">
        /// Паттерн поиска
        /// </param>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        IList<ICountry> GetCountryCollectionByName(string pattern);
    }
}