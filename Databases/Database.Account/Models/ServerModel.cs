using Database.Account.Enums;

namespace Database.Account.Models
{
    /// <summary>
    ///     Server model
    /// </summary>
    public class ServerModel
    {
        public ServerModel()
        {
            
        }

        public int Id { get; set; }

        /// <summary>
        ///     Server id
        /// </summary>
        public int ServerId { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Type
        /// </summary>
        public ServerType Type { get; set; }
        
        /// <summary>
        ///     Hidden
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        ///     Server ip
        /// </summary>
        public string ServerIp { get; set; }
        
        /// <summary>
        ///     Server port
        /// </summary>
        public int ServerPort { get; set; }

        /// <summary>
        ///     Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///     Congestion
        /// </summary>
        public CongestionType Congestion { get; set; }
    }
}
