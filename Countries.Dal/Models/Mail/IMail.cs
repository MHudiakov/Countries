namespace Countries.Dal.Models.Mail
{
    /// <summary>
    /// Интерфейс модели e-mail сообщения
    /// </summary>
    public interface IMail
    {
        string SmtpServer { get; set; }

        string From { get; set; }

        string Password { get; set; }

        string To { get; set; }

        string Caption { get; set; }

        string Message { get; set; }

        int Port { get; set; }
    }
}