using Countries.Dal.Models.Settings;

namespace Countries.Dal.Repositories.SettingsRepository
{
    /// <summary>
    /// Интерфейс репозитория настроек
    /// </summary>
    public interface ISettingsRepository
    {
        /// <summary>
        /// Настройки приложения
        /// </summary>
        ISettings Settings { get; set; }
    }
}