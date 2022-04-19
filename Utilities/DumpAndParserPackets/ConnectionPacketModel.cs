namespace DumpAndParserPackets
{
    /// <summary>
    ///     This base class connection packet
    /// </summary>
    public class ConnectionPacketModel
    {
        /// <summary>
        ///     Identity packet
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Data has array bytes
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Type packet connection
        /// </summary>
        public ConnectionPacketType Type { get; set; }

        /// <summary>
        ///     Flag if this is packet was decrypted
        /// </summary>
        public bool IsDecrypted { get; set; }

        /// <summary>
        ///     Unique identity packet
        /// </summary>
        public string Opcode { get; set; }
    }

    /// <summary>
    ///     Type connection packet type
    /// </summary>
    public enum ConnectionPacketType
    {
        ClientToServer = 1,
        ServerToClient = 2
    }
}
