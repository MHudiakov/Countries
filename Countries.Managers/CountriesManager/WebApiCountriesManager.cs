using System.Collections.Generic;
using System.Net;
using Countries.Dal.Models.Country;
using Countries.Dal.Models.Currency;
using Newtonsoft.Json.Linq;

namespace Countries.Managers.CountriesManager
{
    /// <summary>
    /// Countri manager (uses WEB API for getting countries info)
    /// </summary>
    public class WebApiCountriesManager : ICountriesManagerStrategy
    {
        /// <summary>
        /// Countries service URL
        /// </summary>
        private const string DataUrl = "https://restcountries.eu/rest/v2/all";

        /// <summary>
        /// Get country collection
        /// </summary>
        /// <returns>
        /// Country collection
        /// </returns>
        public IEnumerable<ICountry> GetCountries()
        {
            // Create the resulting list of countries
            IList<ICountry> countryCollection = new List<ICountry>();

            // Get countries JSON
            string countriesJsonStr = GetCountriesJson();
            JArray countriesJson = JArray.Parse(countriesJsonStr);

            // Formed country model according to the obtained JSON
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
        /// Get JSON with a list of countries from external service
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