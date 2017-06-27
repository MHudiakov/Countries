using Countries.Dal.Enums;

namespace Countries.Dal.Models.Settings
{
    /// <summary>
    /// App settings model
    /// </summary>
    public sealed class Settings : ISettings
    {
        public string Email { get; set; }
        public Languages Language { get; set; }
        public void Update(ISettings settings)
        {
            Email = settings.Email;
            Language = settings.Language;
        }
    }
}