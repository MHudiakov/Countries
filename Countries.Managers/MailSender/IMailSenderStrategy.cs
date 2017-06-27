using Countries.Dal.Models.Mail;

namespace Countries.Managers.MailSender
{
    /// <summary>
    /// E-mail sending strategy
    /// </summary>
    public interface IMailSenderStrategy
    {
        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="mailModel">
        /// E-mail model
        /// </param>
        void Send(IMail mailModel);
    }
}