using Countries.Dal.Models.Settings;

namespace Countries.Dal.Repositories.SettingsRepository
{
    /// <summary>
    /// Settings repository interface
    /// </summary>
    public interface ISettingsRepository
    {
        /// <summary>
        /// App settings
        /// </summary>
        ISettings Settings { get; set; }
    }
}