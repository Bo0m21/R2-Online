namespace Server.Login.Models.Settings
{
    /// <summary>
    ///     Config for settings login server
    /// </summary>
    public class LoginSetting
    {
        public short Id { get; set; }

        public string ServerIp { get; set; }
        public short ServerPort { get; set; }
    }
}