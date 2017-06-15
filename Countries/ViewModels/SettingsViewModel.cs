using System.ComponentModel;
using System.Runtime.CompilerServices;
using Countries.Dal.Enums;
using Countries.Dal.Models.Settings;

namespace Countries.ViewModels
{
    internal class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly ISettings _settings;

        public SettingsViewModel(ISettings settings)
        {
            _settings = settings;
        }

        public string Email
        {
            get { return _settings.Email; }
            set
            {
                _settings.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public Languages Language
        {
            get { return _settings.Language; }
            set
            {
                _settings.Language = value;
                OnPropertyChanged("Language");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
