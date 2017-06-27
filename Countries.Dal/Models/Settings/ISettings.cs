using Countries.Dal.Enums;

namespace Countries.Dal.Models.Settings
{
    /// <summary>
    /// App settings model interface
    /// </summary>
    public interface ISettings
    {
        string Email { get; set; }

        Languages Language { get; set; }

        void Update(ISettings settings);
    }
}
