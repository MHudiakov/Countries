using Countries.Managers.CountriesManager;

namespace Countries.Managers.Factories.CountriesManagerFactory
{
    /// <summary>
    /// Abstract factory for creating countries manager 
    /// </summary>
    public abstract class AbstractCountriesManagerFactory
    {
        public abstract ICountriesManagerStrategy CreateCountriesManager();
    }
}