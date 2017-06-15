using System;
using Countries.Dal.Repositories.CountryRepository;
using Countries.Dal.Repositories.SettingsRepository;

namespace Countries.Dal.DataManager
{
    /// <summary>
    /// Менеджер доступа к данным
    /// </summary>
    public class DataManager : IDataManager
    {
        public DataManager()
        {
            /////////////////////////////////////
            // Создаем и регистрируем репозитории
            /////////////////////////////////////

            // Репозиторий стран
            _countryRepository =
                new Lazy<ICountryRepository>(() => new CountryRepository(), 
                    true);

            // Репозиторий настроек
            _settingsRepository = 
                new Lazy<ISettingsRepository>(() => new SettingsRepository(),
                true);
        }

        #region CountryRepository

        /// <summary>
        /// Кэшированная ссылка на репозиторий стран
        /// </summary>
        private readonly Lazy<ICountryRepository> _countryRepository;

        /// <summary>
        /// Репозиторий стран
        /// </summary>
        public ICountryRepository CountryRepository => _countryRepository.Value;

        #endregion

        #region SettingsRepository

        /// <summary>
        /// Кэшированная ссылка на репозиторий настроек
        /// </summary>
        private readonly Lazy<ISettingsRepository> _settingsRepository;

        /// <summary>
        /// Репозиторий настроек
        /// </summary>
        public ISettingsRepository SettingsRepository => _settingsRepository.Value;

        #endregion
    }
}