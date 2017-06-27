using Countries.Managers.CountriesManager;

namespace Countries.Managers.Factories.CountriesManagerFactory
{
    /// <summary>
    /// Factory for creating countries manager
    /// </summary>
    public class CountriesManagerFactory : AbstractCountriesManagerFactory
    {
        public override ICountriesManagerStrategy CreateCountriesManager()
        {
            return new WebApiCountriesManager();
        }
    }
}