using System.ComponentModel;
using System.Runtime.CompilerServices;
using Countries.Dal.Enums;
using Countries.Dal.Models.Settings;

namespace Countries.ViewModels
{
    using Countries.Dal;
    using Countries.Dal.Models.Country;

    internal class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly string _message;

        public SettingsViewModel(string message)
        {
            this._message = message;
        }

        #region Email

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        #endregion

        #region Language

        private Languages _languages;

        public Languages Language
        {
            get { return this._languages; }
            set
            {
                this._languages = value;
                OnPropertyChanged("Language");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
