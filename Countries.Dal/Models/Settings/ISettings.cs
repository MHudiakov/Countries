using Countries.Dal.Enums;

namespace Countries.Dal.Models.Settings
{
    /// <summary>
    /// Интерфейс модели настроек приложения
    /// </summary>
    public interface ISettings
    {
        string Email { get; set; }

        Languages Language { get; set; }

        void Update(ISettings settings);
    }
}
