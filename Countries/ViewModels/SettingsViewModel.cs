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
            Email = settings.Email;
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

        private BaseCommand _applySettingsCommand;

        public BaseCommand ApplySettingsCommand
        {
            get
            {
                return _applySettingsCommand ??
                       (_applySettingsCommand = new BaseCommand(obj =>
                                {
                                    // Отправляем письмо
                                    this.SendMail();

                                    // Меняем язык
                                    CultureInfo lang;
                                    switch (Language)
                                    {
                                        case Languages.Eng:
                                            lang = new CultureInfo("en-EN");
                                            break;
                                        case Languages.Rus:
                                            lang = new CultureInfo("ru-RU");
                                            break;
                                        default:
                                            lang = new CultureInfo("en-EN");
                                            break;
                                    }

                                    App.Language = lang;
                                }
                        ));
            }
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
                mail.Caption = "Информация по стране";
                mail.Message = this._message;
                AbstractMailSenderFactory mailSenderFactory = new MailSenderFactory();
                IMailSenderStrategy mailSenderStrategy = mailSenderFactory.CreateMailSender();
                mailSenderStrategy.Send(mail);
                MessageBox.Show("Ваше письмо было успешно отправлено");

                ISettings settings = DalContainer.GetDataManager.SettingsRepository.Settings;
                settings.Email = Email;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось отправить письмо");
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
