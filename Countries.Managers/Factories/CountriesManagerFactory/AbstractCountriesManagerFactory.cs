using Countries.Managers.CountriesManager;

namespace Countries.Managers.Factories.CountriesManagerFactory
{
    /// <summary>
    /// Абстрактная фабрика по созданию менеджера получения списка стран
    /// </summary>
    public abstract class AbstractCountriesManagerFactory
    {
        public abstract ICountriesManagerStrategy CreateCountriesManager();
    }
}