using System.Collections.Generic;
using System.Net;
using Countries.Dal.Models.Country;
using Countries.Dal.Models.Currency;
using Newtonsoft.Json.Linq;

namespace Countries.Managers.CountriesManager
{
    /// <summary>
    /// Менеджер получения списка стран с использованием Web API
    /// </summary>
    public class WebApiCountriesManager : ICountriesManagerStrategy
    {
        /// <summary>
        /// Адрес сервиса работы со списком стран
        /// </summary>
        private const string DataUrl = "https://restcountries.eu/rest/v2/all";

        /// <summary>
        /// Получить коллекцию стран
        /// </summary>
        /// <returns>
        /// Коллекция стран
        /// </returns>
        public IEnumerable<ICountry> GetCountries()
        {
            // Создаем результирующий список стран
            IList<ICountry> countryCollection = new List<ICountry>();

            // Получаем JSON стран
            string countriesJsonStr = GetCountriesJson();
            JArray countriesJson = JArray.Parse(countriesJsonStr);

            // Формируем модель страны по полученному JSON
            foreach (JObject countryJson in countriesJson.Children<JObject>())
            {
                ICountry country = new Country();
                country.Name = countryJson.SelectToken("name").ToString();
                country.Capital = countryJson.SelectToken("capital").ToString();

                JArray currenciesJson = (JArray)countryJson.SelectToken("currencies");
                IList<ICurrency> currencyCollection = new List<ICurrency>();
                foreach (JObject currencyJson in currenciesJson.Children<JObject>())
                {
                    ICurrency currency = new Currency();
                    currency.Name = currencyJson.SelectToken("name").ToString();
                    currencyCollection.Add(currency);
                }

                country.CurrencyCollection = currencyCollection;
                countryCollection.Add(country);
            }

            return countryCollection;

        }

        /// <summary>
        /// Получить JSON со списком стран с внешнего сервиса
        /// </summary>
        /// <returns></returns>
        private string GetCountriesJson()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(DataUrl);
                return json;
            }
        }
    }
}