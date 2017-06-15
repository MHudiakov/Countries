using Countries.Managers.CountriesManager;

namespace Countries.Managers.Factories.CountriesManagerFactory
{
    /// <summary>
    /// Фабрика по созданию менеджера получения списка стран
    /// </summary>
    public class CountriesManagerFactory : AbstractCountriesManagerFactory
    {
        public override ICountriesManagerStrategy CreateCountriesManager()
        {
            return new WebApiCountriesManager();
        }
    }
}