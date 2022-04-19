﻿namespace Database.Account.Models
{
    /// <summary>
    ///     Session model
    /// </summary>
    public class SessionModel
    {
        public SessionModel()
        {
        
        }

        public int Id { get; set; }

        /// <summary>
        ///     Account id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Server id
        /// </summary>
        public int? ServerId { get; set; }
        
        /// <summary>
        ///     Is in game
        /// </summary>
        public bool InGame { get; set; }
    }
}