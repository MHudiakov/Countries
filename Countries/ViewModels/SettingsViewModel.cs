using System.ComponentModel;
using System.Runtime.CompilerServices;
using Countries.Dal.Enums;
using Countries.Dal.Models.Settings;

namespace Countries.ViewModels
{
    using System;
    using System.Globalization;
    using System.Windows;

    using Countries.Commands;
    using Countries.Dal;
    using Countries.Dal.Models.Mail;
    using Countries.Managers.Factories.MailSenderFactory;
    using Countries.Managers.MailSender;

    internal class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly string _message;

        public SettingsViewModel(string message)
        {
            this._message = message;
            ISettings settings = DalContainer.GetDataManager.SettingsRepository.Settings;
            this.ApplySettingsCommand = new BaseCommand(ApplySettings);
            Email = settings.Email;


            switch (App.Language.Name)
            {
                case "ru-RU":
                    Language = Languages.Rus;
                    break;
                case "en-US":
                    Language = Languages.Eng;
                    break;
            }
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

        #region ApplySettingsCommand

        public BaseCommand ApplySettingsCommand { get; }

        private void ApplySettings(object window)
        {
            // Send mail
            this.SendMail();

            // Change language
            CultureInfo lang;
            switch (Language)
            {
                case Languages.Eng:
                    lang = new CultureInfo("en-US");
                    break;
                case Languages.Rus:
                    lang = new CultureInfo("ru-RU");
                    break;
                default:
                    lang = new CultureInfo("en-US");
                    break;
            }

            App.Language = lang;

            // Close window
            ((Window)window)?.Close();
        }

        private void SendMail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                return;
            }

            try
            {
                IMail mail = new Mail();
                mail.SmtpServer = Properties.Settings.Default.SmtpServer;
                mail.From = Properties.Settings.Default.MailAddress;
                mail.Password = Properties.Settings.Default.Password;
                mail.Port = Properties.Settings.Default.Port;
                mail.To = Email;
                mail.Caption = "Country info";
                mail.Message = this._message;
                AbstractMailSenderFactory mailSenderFactory = new MailSenderFactory();
                IMailSenderStrategy mailSenderStrategy = mailSenderFactory.CreateMailSender();
                mailSenderStrategy.Send(mail);
                MessageBox.Show("Your email was successfully sent");

                ISettings settings = DalContainer.GetDataManager.SettingsRepository.Settings;
                settings.Email = Email;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send email");
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