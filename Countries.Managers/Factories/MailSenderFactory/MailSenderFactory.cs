using Countries.Managers.MailSender;

namespace Countries.Managers.Factories.MailSenderFactory
{
    /// <summary>
    /// Factory for creating e-mail sending manager
    /// </summary>
    public class MailSenderFactory : AbstractMailSenderFactory
    {
        public override IMailSenderStrategy CreateMailSender()
        {
            return new NetMailSender();
        }
    }
}
