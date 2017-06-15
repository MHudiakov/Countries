using Countries.Dal.Repositories.CountryRepository;
using Countries.Dal.Repositories.SettingsRepository;

namespace Countries.Dal.DataManager
{
    /// <summary>
    /// Интерфейс менеджера данных
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Репозиторий стран
        /// </summary>
        ICountryRepository CountryRepository { get; }

        /// <summary>
        /// Репозиторий настроек
        /// </summary>
        ISettingsRepository SettingsRepository { get; }
    }
}