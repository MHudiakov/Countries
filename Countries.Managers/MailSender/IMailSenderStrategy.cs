using Countries.Dal.Models.Mail;

namespace Countries.Managers.MailSender
{
    /// <summary>
    /// Стратегия отправки e-mail
    /// </summary>
    public interface IMailSenderStrategy
    {
        void Send(IMail mailModel);
    }
}