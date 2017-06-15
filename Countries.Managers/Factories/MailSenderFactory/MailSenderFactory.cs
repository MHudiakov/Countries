using Countries.Managers.MailSender;

namespace Countries.Managers.Factories.MailSenderFactory
{
    /// <summary>
    /// Фабрика по созданию менеджера отправки сообщений
    /// </summary>
    public class MailSenderFactory : AbstractMailSenderFactory
    {
        public override IMailSenderStrategy CreateMailSender()
        {
            return new NetMailSender();
        }
    }
}
