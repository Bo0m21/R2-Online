namespace Packets.Server.Login.Models.Send.Models
{
    /// <summary>
    ///     Server model
    /// </summary>
    public class ServerModel
    {
        public short Id { get; set; }

        public string Name { get; set; }
        public bool Status { get; set; }
        public CongestionType Congestion { get; set; }
        public ServerType Type { get; set; }
        public bool Hidden { get; set; }

        public string ServerIp { get; set; }
        public short ServerPort { get; set; }
    }

    /// <summary>
    ///     Server type
    /// </summary>
    public enum ServerType : byte
    {
        Server = 0x01,
        OpenServer = 0x02
    }

    /// <summary>
    ///     Congestion type
    /// </summary>
    public enum CongestionType : byte
    {
        Low = 0x00,
        Medium = 0x01,
        High = 0x02,
        Maximum = 0x03
    }
}
