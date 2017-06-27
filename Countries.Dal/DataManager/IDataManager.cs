using Countries.Dal.Repositories.CountryRepository;
using Countries.Dal.Repositories.SettingsRepository;

namespace Countries.Dal.DataManager
{
    /// <summary>
    /// The data access Manager interface
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Country repository
        /// </summary>
        ICountryRepository CountryRepository { get; }

        /// <summary>
        /// Settings repository
        /// </summary>
        ISettingsRepository SettingsRepository { get; }
    }
}