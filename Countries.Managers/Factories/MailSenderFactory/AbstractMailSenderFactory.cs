using Countries.Managers.MailSender;

namespace Countries.Managers.Factories.MailSenderFactory
{
    /// <summary>
    /// Абстрактная фабрика по созданию менеджера отправки сообщений
    /// </summary>
    public abstract class AbstractMailSenderFactory
    {
        public abstract IMailSenderStrategy CreateMailSender();
    }
}