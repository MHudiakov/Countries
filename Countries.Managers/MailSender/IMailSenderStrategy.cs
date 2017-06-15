using Countries.Dal.Models.Mail;

namespace Countries.Managers.MailSender
{
    /// <summary>
    /// Стратегия отправки e-mail
    /// </summary>
    public interface IMailSenderStrategy
    {
        /// <summary>
        /// Отправить письмо получателю
        /// </summary>
        /// <param name="mailModel">
        /// Модель письма
        /// </param>
        void Send(IMail mailModel);
    }
}