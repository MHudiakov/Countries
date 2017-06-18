namespace Countries.Dal.Models.Mail
{
    /// <summary>
    /// Модель e-mail сообщения
    /// </summary>
    public sealed class Mail : IMail
    {
        public string SmtpServer { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Caption { get; set; }
        public string Message { get; set; }
        public int Port { get; set; }
    }
}