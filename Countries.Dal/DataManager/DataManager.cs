using System;
using Countries.Dal.Repositories.CountryRepository;
using Countries.Dal.Repositories.SettingsRepository;

namespace Countries.Dal.DataManager
{
    /// <summary>
    /// The data access manager
    /// </summary>
    public class DataManager : IDataManager
    {
        public DataManager()
        {
            /////////////////////////////////////
            // Create and register repositories
            /////////////////////////////////////

            // Country repository
            _countryRepository =
                new Lazy<ICountryRepository>(() => new CountryRepository(), 
                    true);

            // Settings repository
            _settingsRepository = 
                new Lazy<ISettingsRepository>(() => new SettingsRepository(),
                true);
        }

        #region CountryRepository

        /// <summary>
        /// Cached reference to the country repository
        /// </summary>
        private readonly Lazy<ICountryRepository> _countryRepository;

        /// <summary>
        /// Country repository
        /// </summary>
        public ICountryRepository CountryRepository => _countryRepository.Value;

        #endregion

        #region SettingsRepository

        /// <summary>
        /// Cached reference to the settings repository
        /// </summary>
        private readonly Lazy<ISettingsRepository> _settingsRepository;

        /// <summary>
        /// Settings repository
        /// </summary>
        public ISettingsRepository SettingsRepository => _settingsRepository.Value;

        #endregion
    }
}