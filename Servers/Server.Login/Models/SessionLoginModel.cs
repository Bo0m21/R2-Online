namespace Server.Login.Models.Login
{
    /// <summary>
    ///     Session login model
    /// </summary>
    public class SessionLoginModel
    {
        /// <summary>
        ///     Account id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Session id
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        ///     Is in game
        /// </summary>
        public bool InGame { get; set; }
    }
}
