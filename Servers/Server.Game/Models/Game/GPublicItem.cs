using Packets.Server.Game.Structures;
using Server.Game.Network;
using System;
using System.Collections.Generic;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Public item game model
    /// </summary>
    public class GPublicItem
    {
        public GPublicItem()
        {
            Item = new GItem();
            Position = new Vector3();
        }

        #region General field
        /// <summary>
        ///     Unique identifier
        /// </summary>
        public UniqueId UniqueId { get; set; }

        /// <summary>
        ///     Item
        /// </summary>
        public GItem Item { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        ///     Visible character game
        /// </summary>
        public List<GameSession> VisibleCharacterGames { get; set; }
        #endregion

        #region Other fields
        /// <summary>
        ///     Is vsible first
        /// </summary>
        public bool IsVsibleFirst { get; set; }

        /// <summary>
        ///     Date create
        /// </summary>
        public DateTime DateCreate { get; set; }
        #endregion
    }
}
