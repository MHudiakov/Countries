using Countries.Dal.Models.Settings;

namespace Countries.Dal.Repositories.SettingsRepository
{
    /// <summary>
    /// Settings repository
    /// </summary>
    public sealed class SettingsRepository : ISettingsRepository
    {
        public SettingsRepository()
        {
            Settings = new Settings();
        }

        /// <summary>
        /// App settings
        /// </summary>
        public ISettings Settings { get; set; }
    }
}