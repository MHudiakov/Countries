using Countries.Dal.Models.Settings;

namespace Countries.Dal.Repositories.SettingsRepository
{
    /// <summary>
    /// Репозиторий настроек
    /// </summary>
    public class SettingsRepository : ISettingsRepository
    {
        /// <summary>
        /// Настройки приложения
        /// </summary>
        public ISettings Settings { get; set; }
    }
}