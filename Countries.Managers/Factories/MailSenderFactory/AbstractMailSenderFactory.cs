using Countries.Managers.MailSender;

namespace Countries.Managers.Factories.MailSenderFactory
{
    /// <summary>
    /// Abstract factory for creating e-mail sending manager
    /// </summary>
    public abstract class AbstractMailSenderFactory
    {
        public abstract IMailSenderStrategy CreateMailSender();
    }
}