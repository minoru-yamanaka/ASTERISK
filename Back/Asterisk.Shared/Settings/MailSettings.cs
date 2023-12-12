namespace Asterisk.Shared.Settings
{
    public class MailSettings
    {
        public string From { get; set; } = String.Empty;
        public string DisplayName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Host { get; set; } = String.Empty;
        public int Port { get; set; }
    }
}
